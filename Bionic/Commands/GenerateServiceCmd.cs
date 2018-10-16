using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using BionicCore;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;
using static BionicCore.DirectoryUtils;

namespace BionicCLI.Commands {
  [Command(Description = "Generate Blazor service")]
  public class GenerateServiceCmd : CommandBase, ICommand {
    private const string ProgramPath = "Startup.cs";

    private static readonly Regex ServiceRegEx =
      new Regex(@"BrowserServiceProvider[^(]*\([\s]*(.*?)=>[\s]*{([^}]*)}", RegexOptions.Compiled);

    [Argument(0, Description = "Artifact Name"), Required]
    private string Artifact { get; set; }

    public GenerateCommand Parent { get; }

    public GenerateServiceCmd() { }

    public GenerateServiceCmd(string artifact) => Artifact = artifact;

    protected override int OnExecute(CommandLineApplication app) => GenerateService();

    public int Execute() => GenerateService();

    private int GenerateService() {
      Logger.Success($"Generating a service named {Artifact}");
      return DotNetHelper.RunDotNet(ToOSPath($"new bionic.service -n {Artifact} -o ./Services"));
    }
  }
}