using System.ComponentModel.DataAnnotations;
using System.IO;
using BionicCore;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;
using static BionicCore.DirectoryUtils;

namespace BionicCLI.Commands {
  [Command(Description = "Generate Blazor layout")]
  public class GenerateLayoutCmd : CommandBase, ICommand {
    [Argument(0, Description = "Artifact Name"), Required]
    private string Artifact { get; set; }

    [Option("-n|--no-styles", Description = "Do not generate page style file")]
    private bool noStyles { get; set; } = false;

    public GenerateCommand Parent { get; }

    public GenerateLayoutCmd() { }

    public GenerateLayoutCmd(string artifact) => Artifact = artifact;

    protected override int OnExecute(CommandLineApplication app) => GenerateLayout();

    public int Execute() => GenerateLayout();

    private int GenerateLayout() {
      Logger.Success($"Generating a layout named {Artifact}");
      var dest = ToOSPath("./Layouts");
      DotNetHelper.RunDotNet($"new bionic.layout -n {Artifact} -o {dest}");
      if (noStyles) File.Delete($"{dest}/{Artifact}.scss");
      return noStyles ? 0 : GenerateCommand.IntroduceAppCssImport("Layouts", Artifact);
    }
  }
}