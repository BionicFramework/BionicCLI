using System;
using System.Reflection;
using Bionic.Factories;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Print Bionic serial number")]
  public class VersionCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => PrintVersion();

    public int Execute() => PrintVersion();

    public BionicCommandFactory Parent { get; }

    private static int PrintVersion() {
      var informationalVersion = ((AssemblyInformationalVersionAttribute) Attribute.GetCustomAttribute(
          Assembly.GetExecutingAssembly(), typeof(AssemblyInformationalVersionAttribute), false))
        .InformationalVersion;
      Console.WriteLine($"🤖 Bionic v{informationalVersion}");
      return 0;
    }
  }
}