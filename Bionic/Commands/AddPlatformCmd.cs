using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Bionic.Project;
using McMaster.Extensions.CommandLineUtils;

namespace Bionic.Commands {
  [Command(Description = "Add available Bionic platforms to project")]
  public class AddPlatformCmd : CommandBase, ICommand {
    [Argument(0, Description = "Platform Name (electron, capacitor)"), Required]
    private string PlatformName { get; set; }

    public PlatformCommand Parent { get; }

    public AddPlatformCmd() { }

    public AddPlatformCmd(string platformName) => this.PlatformName = platformName;

    protected override int OnExecute(CommandLineApplication app) => AddPlatform();

    public int Execute() => AddPlatform();

    private int AddPlatform() {
      Console.WriteLine($"🔍  Looking for {PlatformName} platform plugin");

      var packageId = $"bionic{PlatformName}plugin";

      if (!ProjectHelper.InClientOrStandaloneDir()) {
        Console.WriteLine($"☠  Must be in a Blazor Standalone or Client (if Hosted) directory");
        return 0;
      }

      if (Directory.Exists($".bionic/{packageId}")) {
        Console.WriteLine($"🚀  {PlatformName} platform is already available");
        return 0;
      }

      if (IsPackageAvailable(packageId)) {
        Console.WriteLine($"☕  Found it! Adding {PlatformName} plugin...");
        Console.WriteLine(InstallPackage(packageId)
          ? $"🚀  {PlatformName} platform successfully added"
          : $"☠  Something went wrong while trying to add platform plugin named: {PlatformName}");
      }
      else {
        Console.WriteLine($"😟  Bionic was unable to find a platform plugin named: {PlatformName}");
      }

      return 0;
    }

    private static bool IsPackageAvailable(string packageID) {
      var output = "";
      var process = Process.Start(
        new ProcessStartInfo("nuget", $"list {packageID}") {
          CreateNoWindow = true,
          UseShellExecute = false,
          RedirectStandardOutput = true
        }
      );
      process.OutputDataReceived += (sender, args) => output += args.Data;
      process.Start();
      process.BeginOutputReadLine();
      process.WaitForExit();

      var entries = output.Split(
        new[] {Environment.NewLine},
        StringSplitOptions.None
      );

      return entries.Any(entry => entry.ToLower().Contains(packageID));
    }

    private static bool InstallPackage(string packageID) {
      var output = "";
      var process = Process.Start(
        new ProcessStartInfo("nuget",
          $"install {packageID} -DirectDownload -ExcludeVersion -PackageSaveMode nuspec -o .bionic") {
          CreateNoWindow = true,
          UseShellExecute = false,
          RedirectStandardOutput = true
        });
      process.OutputDataReceived += (sender, args) => output += args.Data;
      process.Start();
      process.BeginOutputReadLine();
      process.WaitForExit();

      var entries = output.Split(Environment.NewLine);
      if (entries.Any(entry => entry.Contains("Successfully installed"))) {
        return true;
      }

      Console.WriteLine(output);
      return false;
    }
  }
}