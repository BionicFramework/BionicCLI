using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Bionic.Factories;
using Bionic.Project;
using Bionic.Utils;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Prepares Blazor project to mimic Ionic structure")]
  public class StartCommand : CommandBase, ICommand {
    private const string StartupPath = "Startup.cs";

    private static readonly Regex ServiceRegEx =
      new Regex(@"(ConfigureServices\([\s]*IServiceCollection[\s]+(.*?)[\s]*\)[\s]*{)([^}]*)(})",
        RegexOptions.Compiled);

    protected override int OnExecute(CommandLineApplication app) => SetupBionic();

    public int Execute() => SetupBionic();

    public BionicCommandFactory Parent { get; }

    private static int SetupBionic() {
      Console.WriteLine($"🤖  Preparing your Bionic Project...");

      // 1. Get project file name
      var projectFiles = ProjectHelper.GetProjectFiles();
      if (projectFiles.IsNullOrEmpty()) {
        Console.WriteLine($"☠ No C# project found. Please make sure you are in the root of a C# project.");
        return 1;
      }

      var currentDir = Directory.GetCurrentDirectory();

      foreach (var pi in projectFiles) {
        if (pi.projectType == ProjectType.Unknown) continue;

        Directory.SetCurrentDirectory(pi.dir);

        if (pi.projectType != ProjectType.HostedServer) {
          // 2. Create App.scss
          var alreadyStarted = InitAppCss();

          if (alreadyStarted) {
            alreadyStarted = Prompt.GetYesNo(
              "Project seems to have already been started. Are you sure you want to continue?",
              false,
              promptColor: ConsoleColor.DarkGreen
            );
            if (!alreadyStarted) {
              Console.WriteLine("Ok! Bionic start canceled.");
              return 0;
            }
          }

          // 3. Inject App.css in index.html
          InjectAppCssInIndexHtml();

          // 4. Inject targets in .csproj
          IntroduceProjectTargets(pi);

          // 5. Install Bionic Templates
          InstallBionicTemplates();

          // 6. Add Bionic Extensions
          InstallBionicExtensions();

          // 7. Add Bionic Extension Injectable Attribute to Startup.cs
          UpdateStartup(pi);
        }
        else {
          // 1. Its Hosted ... Inject targets in .csproj
          var client = projectFiles.FirstOrDefault(p => p.projectType == ProjectType.HostedClient);
          if (client.filename == null) {
            Console.WriteLine("☠  Unable to start project. Client directory for Hosted Blazor project was not found.");
            return 1;
          }

          IntroduceProjectTargets(pi, Path.GetRelativePath(pi.dir, client.dir));
        }

        Directory.SetCurrentDirectory(currentDir);
      }

      ProjectHelper.RestoreAdjustedDir();

      return 0;
    }

    private static bool InitAppCss() {
      if (File.Exists(ProjectHelper.AppCssPath)) return true;

      using (var sw = File.CreateText(ProjectHelper.AppCssPath)) {
        sw.WriteLine("// WARNING - This file is automatically updated by Bionic CLI, please do not remove");
        sw.WriteLine("\n// Components\n\n// Pages\n\n// Layouts\n");
      }

      return false;
    }

    private static void InjectAppCssInIndexHtml() {
      FileHelper.SeekForLineStartingWithAndInsert(
        "wwwroot/index.html",
        "    <link href=\"css/site.css",
        "    <link href=\"css/App.css\" rel=\"stylesheet\" />",
        false
      );
    }

    private static void IntroduceProjectTargets(ProjectInfo projectInfo, string relativePath = "") {
      var watcher = string.Format(@"
    <ItemGroup>
        <Watch Include=""{0}**/*.cshtml;{0}**/*.scss"" Visible=""false""/>
    </ItemGroup>", relativePath.IsNullOrEmpty() || relativePath.EndsWith("/") ? relativePath : $"{relativePath}/");

      const string scssCompiler = @"
    <Target Name=""CompileSCSS"" BeforeTargets=""Build"" Condition=""Exists('App.scss')"">
        <Message Importance=""high"" Text=""Compiling SCSS"" />
        <Exec Command=""sass --update ./App.scss:./wwwroot/css/App.css"" />
    </Target>";

      string content;

      switch (projectInfo.projectType) {
        case ProjectType.Standalone:
          content = $"{watcher}\n\n{scssCompiler}";
          break;
        case ProjectType.HostedServer:
          content = $"{watcher}";
          break;
        case ProjectType.HostedClient:
          content = $"{scssCompiler}";
          break;
        case ProjectType.Unknown:
          return;
        default:
          return;
      }

      FileHelper.SeekForLineStartingWithAndInsert(projectInfo.filename, "</Project>", content, false);
    }

    private static int InstallBionicTemplates() => DotNetHelper.RunDotNet("new -i BionicTemplates");

    private static int InstallBionicExtensions() => DotNetHelper.RunDotNet("add package BionicExtensions");

    private static int UpdateStartup(ProjectInfo projectInfo) {
      try {
        var all = File.ReadAllText(StartupPath);
        all = $"using BionicExtensions.Attributes;\n{all}";

        var matches = ServiceRegEx.Matches(all);
        var firstEntry = matches[0].Groups[1].Value;
        var browserName = matches[0].Groups[2].Value.Trim().Trim(Environment.NewLine.ToCharArray());

        var newServices =
          $"{firstEntry}\n            InjectableAttribute.RegisterInjectables({browserName});";

        using (var file = new StreamWriter(File.Create(StartupPath))) {
          file.Write(all.Replace(firstEntry, newServices));
        }
      }
      catch (Exception e) {
        Console.WriteLine($"Failed to update Startup.cs: {e.Message}");
        return 1;
      }

      return 0;
    }
  }
}