using System;
using System.Reflection;
using BionicCLI.Factories;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;

namespace BionicCLI.Commands {
  [Command("version", Description = "Print Bionic serial number")]
  public class VersionCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => PrintVersion();

    public int Execute() => PrintVersion();

    public BionicCommandFactory Parent { get; }

    private static int PrintVersion() {
      var informationalVersion = ((AssemblyInformationalVersionAttribute) Attribute.GetCustomAttribute(
          Assembly.GetExecutingAssembly(), typeof(AssemblyInformationalVersionAttribute), false))
        .InformationalVersion;
      Logger.Info($"Bionic v{informationalVersion}");
      return 0;
    }
  }
}