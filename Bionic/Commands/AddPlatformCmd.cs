using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BionicCore.Project;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;
using static BionicCore.DirectoryUtils;

namespace BionicCLI.Commands {
  [Command(Description = "Add available Bionic platforms to project")]
  public class AddPlatformCmd : CommandBase, ICommand {
    [Argument(0, Description = "Platform Name (electron, capacitor)"), Required]
    private string PlatformName { get; set; }

    public PlatformCommand Parent { get; }

    public AddPlatformCmd() { }

    public AddPlatformCmd(string platformName) => PlatformName = platformName;

    protected override int OnExecute(CommandLineApplication app) => AddPlatform();

    public int Execute() => AddPlatform();

    private int AddPlatform() {
      Logger.Search($"Looking for {PlatformName} platform plugin");

      var packageId = $"bionic{PlatformName}plugin";

      if (!ProjectHelper.InClientOrStandaloneDir()) {
        Logger.Error("Must be in a Blazor Standalone or Client (if Hosted) directory");
        return 0;
      }

      if (Directory.Exists(ToOSPath($".bionic/{packageId}"))) {
        Logger.Success($"{PlatformName} platform is already available");
        return 0;
      }

      try {
        if (IsPackageAvailable(packageId)) {
          Logger.Preparing($"Found it! Adding {PlatformName} plugin...");
          Logger.OnSuccessOtherwiseError(
            InstallPackage(packageId),
            $"{PlatformName} platform successfully added",
            $"Something went wrong while trying to add platform plugin named: {PlatformName}"
          );
        }
        else {
          Logger.Sorry($"Bionic was unable to find a platform plugin named: {PlatformName}");
        }
      }
      catch (Exception) {
        Logger.Error("Bionic needs nuget to be available in PATH. Please install nuget CLI.");
        return 1;
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

      Logger.Log(output);
      return false;
    }
  }
}