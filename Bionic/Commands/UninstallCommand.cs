using BionicCLI.Factories;
using BionicCore;
using BionicCore.Project;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;

namespace BionicCLI.Commands {
  [Command(Description = "Initiate Bionic self-destruct sequence")]
  public class UninstallCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => UninstallBionic();

    public int Execute() => UninstallBionic();

    public BionicCommandFactory Parent { get; }

    private static int UninstallBionic() => DotNetHelper.RunDotNet("tool uninstall -g Bionic");
  }
}