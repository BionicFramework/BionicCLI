using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Generate Blazor component")]
  public class GenerateComponentCmd : CommandBase, ICommand {
    [Argument(0, Description = "Artifact Name"), Required]
    private string Artifact { get; set; }

    public GenerateCommand Parent { get; }

    public GenerateComponentCmd() {}

    public GenerateComponentCmd(string artifact) => this.Artifact = artifact;

    protected override int OnExecute(CommandLineApplication app) => GenerateComponent();

    public int Execute() => GenerateComponent();

    private int GenerateComponent() {
      Console.WriteLine($"🚀  Generating a component named {Artifact}");
      Process.Start(
        DotNetExe.FullPathOrDefault(),
        $"new bionic.component -n {Artifact} -o ./Components"
      )?.WaitForExit();
      return GenerateCommand.IntroduceAppCssImport($"Components", Artifact);
    }
  }
}