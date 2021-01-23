using BionicCLI.Factories;
using BionicCore;
using BionicCore.Project;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;

namespace BionicCLI.Commands {
  [Command("update", Description = "Update Bionic to its latest incarnation")]
  public class UpdateCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => UpdateBionic();

    public int Execute() => UpdateBionic();

    public BionicCommandFactory Parent { get; }

    private static int UpdateBionic() => DotNetHelper.RunDotNet("tool update -g Bionic");
  }
}