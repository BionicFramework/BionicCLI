using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.RegularExpressions;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Generate Blazor service")]
  public class GenerateServiceCmd : CommandBase, ICommand {
    private const string ProgramPath = "Startup.cs";

    private static readonly Regex ServiceRegEx =
      new Regex(@"BrowserServiceProvider[^(]*\([\s]*(.*?)=>[\s]*{([^}]*)}", RegexOptions.Compiled);

    [Argument(0, Description = "Artifact Name"), Required]
    private string Artifact { get; set; }

    public GenerateCommand Parent { get; }

    public GenerateServiceCmd() {}

    public GenerateServiceCmd(string artifact) => this.Artifact = artifact;

    protected override int OnExecute(CommandLineApplication app) => GenerateService();

    public int Execute() => GenerateService();

    private int GenerateService() {
      Console.WriteLine($"🚀  Generating a service named {Artifact}");
      var process = Process.Start(
        DotNetExe.FullPathOrDefault(),
        $"new bionic.service -n {Artifact} -o ./Services"
      );
      process?.WaitForExit();
      return process?.ExitCode ?? 1;
    }
  }
}