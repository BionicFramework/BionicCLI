using BionicCLI.Factories;
using BionicCore;
using BionicCore.Project;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;

namespace BionicCLI.Commands {
  [Command("info", Description = "Print environment info")]
  public class InfoCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => Info();

    public int Execute() => Info();

    public BionicCommandFactory Parent { get; }

    private static int Info() {
      new VersionCommand().Execute();
      Logger.NewLine();
      return DotNetHelper.RunDotNet("--info");
    }
  }
}