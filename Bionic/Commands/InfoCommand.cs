using System;
using Bionic.Factories;
using Bionic.Utils;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Print environment info")]
  public class InfoCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => Info();

    public int Execute() => Info();

    public BionicCommandFactory Parent { get; }

    private static int Info() {
      new VersionCommand().Execute();
      Console.WriteLine();
      return DotNetHelper.RunDotNet("--info");
    }
  }
}