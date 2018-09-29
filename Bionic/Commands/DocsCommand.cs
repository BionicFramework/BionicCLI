using Bionic.Factories;
using Bionic.Utils;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Open Blazor documentation page in browser")]
  public class DocsCommand : CommandBase, ICommand {
    protected override int OnExecute(CommandLineApplication app) => OpenBlazorDocs();

    public int Execute() => OpenBlazorDocs();
    
    public BionicCommandFactory Parent { get; }

    private static int OpenBlazorDocs() {
      var browser = UrlHelper.OpenUrl("https://blazor.net");
      browser?.WaitForExit();
      return browser?.ExitCode ?? 1;
    }
  }
}