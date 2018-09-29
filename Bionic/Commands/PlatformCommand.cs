using Bionic.Factories;
using Bionic.Plugin;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Manage available platforms")]
  [Subcommand("add", typeof(AddPlatformCmd))]
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