using System.Diagnostics;

namespace BionicCore {
  public class ProcessHelper {
    public static int RunCmd(string cmd, string args) {
      var process = Process.Start(
        new ProcessStartInfo(cmd, args) {
          CreateNoWindow = true,
          UseShellExecute = false,
          RedirectStandardOutput = false
        }
      );
      process?.WaitForExit();

      return process?.ExitCode ?? 1;
    }

    public static int RunCmdInBackground(string cmd, string args) {
      var process = Process.Start(
        new ProcessStartInfo(cmd, args) {
          CreateNoWindow = true,
          UseShellExecute = false,
          RedirectStandardOutput = false
        }
      );

      return 0;
    }
  }
}