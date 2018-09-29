using Bionic.Factories;
using Bionic.Utils;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Update Bionic to its latest incarnation")]
  public class UpdateCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => UpdateBionic();

    public int Execute() => UpdateBionic();

    public BionicCommandFactory Parent { get; }

    private static int UpdateBionic() => DotNetHelper.RunDotNet("tool update -g Bionic");
  }
}