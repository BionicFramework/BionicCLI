using System.IO;
using System.Linq;
using Bionic.Utils;

namespace Bionic.Project {
  public class ProjectHelper {
    public static readonly string AppCssPath = "App.scss";
    public static string adjustedDir;

    public static bool InClientOrStandaloneDir() => IsClientOrStandaloneDir(Directory.GetCurrentDirectory());

    public static bool IsClientOrStandaloneDir(string dir) {
      var projectInfoList = GetProjectInfoList();
      return projectInfoList.Length == 1 && (
               projectInfoList[0].projectType == ProjectType.Standalone ||
               projectInfoList[0].projectType == ProjectType.HostedClient
             );
    }

    public static void RestoreAdjustedDir() {
      if (adjustedDir != null) Directory.SetCurrentDirectory(ProjectHelper.adjustedDir);
    }

    public static ProjectInfo[] GetProjectFiles(bool onParent = false) {
      var projectInfoList = GetProjectInfoList();
      if (projectInfoList.Length == 1 && projectInfoList[0].projectType != ProjectType.Standalone && !onParent) {
        adjustedDir = Directory.GetCurrentDirectory();
        Directory.SetCurrentDirectory("../");
        projectInfoList = GetProjectFiles(true);
      }

      return projectInfoList;
    }

    private static ProjectInfo[] GetProjectInfoList() {
      var projectFiles = Directory.GetFiles("./", "*.csproj", SearchOption.AllDirectories);
      return projectFiles.ToList().ConvertAll(path => {
        var pi = new ProjectInfo {path = path};
        pi.dir = Path.GetDirectoryName(path);
        pi.filename = Path.GetFileName(path);
        pi.projectType = ProjectType.Unknown;
        if (FileHelper.FileContains(path, "Microsoft.AspNetCore.Blazor.Cli")) {
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