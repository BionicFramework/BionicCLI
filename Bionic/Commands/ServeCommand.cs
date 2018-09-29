using Bionic.Factories;
using Bionic.Utils;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Run hot-reload dev server for app dev/testing")]
  public class ServeCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => ServeBlazor();

    public int Execute() => ServeBlazor();

    public BionicCommandFactory Parent { get; }

    private static int ServeBlazor() => DotNetHelper.RunDotNet("watch run");
  }
}