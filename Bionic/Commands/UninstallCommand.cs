using Bionic.Factories;
using Bionic.Utils;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Initiate Bionic self-destruct sequence")]
  public class UninstallCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => UninstallBionic();

    public int Execute() => UninstallBionic();

    public BionicCommandFactory Parent { get; }

    private static int UninstallBionic() => DotNetHelper.RunDotNet("tool uninstall -g Bionic");
  }
}