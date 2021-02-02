using System.IO;
using System.Linq;
using static BionicCore.DirectoryUtils;

namespace BionicCore.Project {
  public class ProjectHelper {
    public static readonly string AppCssPath = "App.scss";
    private static string adjustedDir;

    public static bool InClientOrStandaloneDir() {
      var projectInfoList = GetProjectInfoList();
      return projectInfoList.Length == 1 && (
               projectInfoList[0].projectType == ProjectType.Standalone ||
               projectInfoList[0].projectType == ProjectType.HostedClient
             );
    }

    public static void RestoreAdjustedDir() {
      if (adjustedDir != null) Directory.SetCurrentDirectory(adjustedDir);
    }

    public static ProjectInfo[] GetProjectFiles(bool onParent = false) {
      var projectInfoList = GetProjectInfoList();
      if (projectInfoList.Length == 1 && projectInfoList[0].projectType != ProjectType.Standalone && !onParent) {
        adjustedDir = Directory.GetCurrentDirectory();
        Directory.SetCurrentDirectory(ToOSPath("../"));
        projectInfoList = GetProjectFiles(true);
      }

      return projectInfoList;
    }

    public static string GetProjectName() {
      var projectFiles = Directory.GetFiles(ToOSPath("./"), "*.csproj", SearchOption.TopDirectoryOnly);
      if (projectFiles.Length == 0) return null;
      return Path.GetFileName(projectFiles[0]).Replace(".csproj", "");
    }
    
    private static ProjectInfo[] GetProjectInfoList() {
      var projectFiles = Directory.GetFiles(ToOSPath("./"), "*.csproj", SearchOption.AllDirectories);
      return projectFiles.ToList().ConvertAll(path => {
        var pi = new ProjectInfo {path = path};
        pi.dir = Path.GetDirectoryName(path);
        pi.filename = Path.GetFileName(path);
        pi.projectType = ProjectType.Unknown;
        if (FileHelper.FileContains(path, "Microsoft.AspNetCore.Blazor.Cli") || FileHelper.FileContains(path, "Microsoft.AspNetCore.Components.WebAssembly")) {
          // Standalone
          pi.projectType = ProjectType.Standalone;
        }
        else if (FileHelper.FileContains(path, "Microsoft.AspNetCore.Blazor.Server")) {
          // Hosted Project - Server
          pi.projectType = ProjectType.HostedServer;
        }
        else if (FileHelper.FileContains(path, "Microsoft.AspNetCore.Blazor.Build")) {
          // Hosted Project - Client
          pi.projectType = ProjectType.HostedClient;
        }

        return pi;
      }).ToArray();
    }
  }
}