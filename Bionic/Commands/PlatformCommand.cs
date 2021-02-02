using BionicCLI.Factories;
using BionicCLI.Plugin;
using BionicCore.Project;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;

namespace BionicCLI.Commands {
  [Command("platform", Description = "Manage available platforms")]
  [Subcommand(typeof(AddPlatformCmd))]
  [LoadPluginCommands]
  public class PlatformCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => ExecutePlatform(app);

    public int Execute() => ExecutePlatform(BionicCommandFactory.cla);

    public BionicCommandFactory Parent { get; }

    private static int ExecutePlatform(CommandLineApplication app) {
      app.ShowHelp();
      return 0;
    }
  }
}