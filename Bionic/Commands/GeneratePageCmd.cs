using System.ComponentModel.DataAnnotations;
using System.IO;
using BionicCore;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;
using static BionicCore.DirectoryUtils;

namespace BionicCLI.Commands {
  [Command(Description = "Generate Blazor page")]
  public class GeneratePageCmd : CommandBase, ICommand {
    [Argument(0, Description = "Artifact Name"), Required]
    private string Artifact { get; set; }

    [Option("-n|--no-styles", Description = "Do not generate page style file")]
    private bool noStyles { get; set; } = false;

    public GenerateCommand Parent { get; }

    public GeneratePageCmd() {}

    public GeneratePageCmd(string artifact) => Artifact = artifact;

    protected override int OnExecute(CommandLineApplication app) => GeneratePage();

    public int Execute() => GeneratePage();

    private int GeneratePage() {
      Logger.Success($"Generating a page named {Artifact}");
      var dest = ToOSPath("./Pages");
      DotNetHelper.RunDotNet(
        $"new bionic.page -n {Artifact} -p /{GenerateCommand.ToPageName(Artifact)} -o {dest}");
      if (noStyles) File.Delete($"{dest}/{Artifact}.scss");
      return noStyles ? 0 : GenerateCommand.IntroduceAppCssImport("Pages", Artifact);
    }
  }
}