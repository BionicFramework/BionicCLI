using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Generate Blazor page")]
  public class GeneratePageCmd : CommandBase, ICommand {
    [Argument(0, Description = "Artifact Name"), Required]
    private string Artifact { get; set; }

    public GenerateCommand Parent { get; }

    public GeneratePageCmd() {}

    public GeneratePageCmd(string artifact) => this.Artifact = artifact;

    protected override int OnExecute(CommandLineApplication app) => GeneratePage();

    public int Execute() => GeneratePage();

    private int GeneratePage() {
      Console.WriteLine($"🚀  Generating a page named {Artifact}");

      Process.Start(
        DotNetExe.FullPathOrDefault(),
        $"new bionic.page -n {Artifact} -p /{GenerateCommand.ToPageName(Artifact)} -o ./Pages"
      )?.WaitForExit();

      return GenerateCommand.IntroduceAppCssImport($"Pages", Artifact);
    }
  }
}