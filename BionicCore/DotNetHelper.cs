using System.Diagnostics;
using McMaster.Extensions.CommandLineUtils;

namespace BionicCore {
  public class DotNetHelper {
    public static int RunDotNet(string cmd) {
      var process = Process.Start(DotNetExe.FullPathOrDefault(), cmd);
      process?.WaitForExit();
      return process?.ExitCode ?? 1;
    }
  }
}