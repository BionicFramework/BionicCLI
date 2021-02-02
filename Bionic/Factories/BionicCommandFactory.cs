using System.Collections.Generic;
using BionicCLI.Commands;
using McMaster.Extensions.CommandLineUtils;

namespace BionicCLI.Factories {
  [Command(Description = "🤖 Bionic - An Ionic CLI clone for Blazor projects")]
  [Subcommand(typeof(BlastCommand))]
  [Subcommand(typeof(DocsCommand))]
  [Subcommand(typeof(GenerateCommand))]
  [Subcommand(typeof(InfoCommand))]
  [Subcommand(typeof(PlatformCommand))]
  [Subcommand(typeof(ServeCommand))]
  [Subcommand(typeof(StartCommand))]
  [Subcommand(typeof(UninstallCommand))]
  [Subcommand(typeof(UpdateCommand))]
  [Subcommand(typeof(VersionCommand))]
  public class BionicCommandFactory {
    public static CommandLineApplication cla = null;
    public static string[] mainArgs = {};

    private static readonly IList<string> commandOptions = new List<string>
      {"docs", "generate", "info", "serve", "start", "uninstall", "update"};

    [Argument(0, Description = "Command Option")]
    private string option { get; set; }

    [Argument(1, Description = "Artifact Name")]
    private string artifact { get; set; }

    [Option("-s|--start", Description = "Prepares Blazor project to mimic Ionic structure")]
    private bool start { get; set; } = false;

    [Option("-g|--generate", Description = "Generate pages, components or services/providers")]
    private bool generate { get; set; } = false;

    [Option("-v|--version", Description = "Print Bionic serial number")]
    private bool version { get; } = false;

    [Option("-u|--update", Description = "Update Bionic to its latest incarnation")]
    private bool update { get; } = false;

    [Option("-un|--uninstall", Description = "Initiate Bionic self-destruct sequence")]
    private bool uninstall { get; } = false;

    private int OnExecute(CommandLineApplication app) {
      if (start) return new StartCommand().Execute();
      if (uninstall) return new UninstallCommand().Execute();
      if (update) return new UpdateCommand().Execute();
      if (version) return new VersionCommand().Execute();

      if (generate) return new GenerateCommand(option, artifact).Execute();

      Logger.Error("You must provide a valid project command!");
      Logger.Log($"   Available Project Commands: {string.Join(", ", commandOptions)}");
      return 0;
    }
  }
}