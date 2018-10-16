using System.ComponentModel.DataAnnotations;
using BionicCore;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;
using static BionicCore.DirectoryUtils;

namespace BionicCLI.Commands {
  [Command(Description = "Generate Blazor component")]
  public class GenerateComponentCmd : CommandBase, ICommand {
    [Argument(0, Description = "Artifact Name"), Required]
    private string Artifact { get; set; }

    public GenerateCommand Parent { get; }

    public GenerateComponentCmd() { }

    public GenerateComponentCmd(string artifact) => Artifact = artifact;

    protected override int OnExecute(CommandLineApplication app) => GenerateComponent();

    public int Execute() => GenerateComponent();

    private int GenerateComponent() {
      Logger.Success($"Generating a component named {Artifact}");
      DotNetHelper.RunDotNet("new bionic.component -n {Artifact} -o " + ToOSPath("./Components"));
      return GenerateCommand.IntroduceAppCssImport("Components", Artifact);
    }
  }
}