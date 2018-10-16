using System.Diagnostics;
using static System.Runtime.InteropServices.OSPlatform;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace BionicCore {
  public class ProcessHelper {
    public static int RunCmd(string cmd, string args) {
      var process = InitProcess(cmd, args);
      process?.WaitForExit();

      return process?.ExitCode ?? 1;
    }

    public static int RunCmdInBackground(string cmd, string args) {
      InitProcess(cmd, args);

      return 0;
    }

    private static Process InitProcess(string command, string arguments) {
      var (cmd, args) = IsOSPlatform(Windows) ? ("cmd.exe", $"/c {command} {arguments}") : (command, arguments);

      return Process.Start(
        new ProcessStartInfo(cmd, args) {
          UseShellExecute = false
        }
      );
    }

    public static (int, string) RunCmdAndCaptureOutput(string command, string arguments) {
      var (cmd, arg) = IsOSPlatform(Windows) ? ("cmd.exe", $"/c {command} {arguments}") : (command, arguments);
      var output = "";
      var process = Process.Start(
        new ProcessStartInfo(cmd, arg) {
          CreateNoWindow = true,
          UseShellExecute = false,
          RedirectStandardOutput = true
        }
      );
      process.OutputDataReceived += (sender, args) => output += args.Data;
      process.Start();
      process.BeginOutputReadLine();
      process.WaitForExit();

      return (process.ExitCode, output);
    }
  }
}