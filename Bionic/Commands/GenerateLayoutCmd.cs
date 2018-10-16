using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using BionicCore.Project;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;
using static BionicCore.DirectoryUtils;

namespace BionicCLI.Commands {
  [Command(Description = "Generate Blazor layout")]
  public class GenerateLayoutCmd : CommandBase, ICommand {
    [Argument(0, Description = "Artifact Name"), Required]
    private string Artifact { get; set; }

    public GenerateCommand Parent { get; }

    public GenerateLayoutCmd() { }

    public GenerateLayoutCmd(string artifact) => Artifact = artifact;

    protected override int OnExecute(CommandLineApplication app) => GenerateLayout();

    public int Execute() => GenerateLayout();

    private int GenerateLayout() {
      Logger.Success($"Generating a layout named {Artifact}");
      Process.Start(
        DotNetExe.FullPathOrDefault(),
        "new bionic.layout -n {Artifact} -o " + ToOSPath("./Layouts")
      )?.WaitForExit();
      return GenerateCommand.IntroduceAppCssImport("Layouts", Artifact);
    }
  }
}