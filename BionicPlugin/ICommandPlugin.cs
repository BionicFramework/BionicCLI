using McMaster.Extensions.CommandLineUtils;

namespace BionicPlugin {
  public interface ICommandPlugin {
    string CommandName { get; }
    void Initialize(CommandLineApplication app);
    int Execute();
    int OnExecute(CommandLineApplication app);
  }
}