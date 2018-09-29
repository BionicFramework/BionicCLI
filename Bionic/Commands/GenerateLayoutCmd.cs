using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Generate Blazor layout")]
  public class GenerateLayoutCmd : CommandBase, ICommand {
    [Argument(0, Description = "Artifact Name"), Required]
    private string Artifact { get; set; }

    public GenerateCommand Parent { get; }

    public GenerateLayoutCmd() {}

    public GenerateLayoutCmd(string artifact) => this.Artifact = artifact;

    protected override int OnExecute(CommandLineApplication app) => GenerateLayout();

    public int Execute() => GenerateLayout();

    private int GenerateLayout() {
      Console.WriteLine($"🚀  Generating a layout named {Artifact}");
      Process.Start(
        DotNetExe.FullPathOrDefault(),
        $"new bionic.layout -n {Artifact} -o ./Layouts"
      )?.WaitForExit();
      return GenerateCommand.IntroduceAppCssImport($"Layouts", Artifact);
    }
  }
}