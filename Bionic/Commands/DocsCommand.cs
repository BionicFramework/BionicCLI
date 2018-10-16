using BionicCLI.Factories;
using BionicCore;
using BionicCore.Project;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;

namespace BionicCLI.Commands {
  [Command(Description = "Open Blazor documentation page in browser")]
  public class DocsCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => OpenBlazorDocs();

    public int Execute() => OpenBlazorDocs();
    
    public BionicCommandFactory Parent { get; }

    private static int OpenBlazorDocs() {
      var browser = BrowserUtils.OpenUrl("https://blazor.net");
      browser?.WaitForExit();
      return browser?.ExitCode ?? 1;
    }
  }
}