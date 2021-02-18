using System;
using System.IO;
using System.Linq;
using BionicCLI;
using static System.Runtime.InteropServices.OSPlatform;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace BionicCore
{
    public static class DirectoryUtils
    {
        public static bool CopyDir(string sourceDirectory, string targetDirectory, bool copySubDirs = true) =>
          CopyDir(new DirectoryInfo(sourceDirectory), new DirectoryInfo(targetDirectory), copySubDirs);

        public static string ToOSPath(string path)
        {
            return IsOSPlatform(Windows) ? path.Replace("/", @"\") : path;
        }

        public static bool CopyDir(DirectoryInfo sourceDirName, DirectoryInfo destDirName, bool copySubDirs = true)
        {
            var dir = sourceDirName;
            Logger.Info($"Working directory {dir}");
            if (!dir.Exists)
            {
                Logger.Error($"{dir} does not exist");
                return false;
            }


            var dirs = dir.GetDirectories();
            if (!destDirName.Exists) Directory.CreateDirectory(destDirName.FullName);

            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var destPath = Path.Combine(destDirName.FullName, file.Name);
                file.CopyTo(destPath, true);
            }

            if (!copySubDirs) return true;

            return !(
              from subdir in dirs
              let destPath = Path.Combine(destDirName.FullName, subdir.Name)
              where !CopyDir(subdir.FullName, destPath, copySubDirs)
              select subdir).Any();
        }

        public static int CopyAndRenameFolders(string cd)
        {
            var wwwroot = ToOSPath($"{cd}/wwwroot");
            var www = ToOSPath($"{cd}/platforms/capacitor/www");
            var release = ToOSPath($"{cd}/bin/Release/net5.0/wwwroot");
            var debug = ToOSPath($"{cd}/bin/Debug/net5.0/wwwroot");
            var scopedCss = ToOSPath($"{cd}/obj/Debug/net5.0/scopedcss/bundle");

            Directory.Delete(www, true);
            Directory.CreateDirectory(www);

            if (!CopyDir(wwwroot, www))
            {
                Logger.Error("Please make sure your are in a Blazor Client or Standalone directory");
                return 1;
            }

            var result = CopyDir(release, www) || CopyDir(debug, www);
            if (!result)
            {
                Logger.Error("Unable to find compiled project or capacitor has not yet been initialized.\nPlease build your project first. e.g.: dotnet build");
                return 1;
            }
            if (!CopyDir(scopedCss, www))
            {
                Logger.Error("Unable to copy scoped CSS files.");
                return 1;
            }
            RenameDirectories(www);
            RemoveFilesByExtension($"{www}/framework", "*.gz");

            return 0;
        }

        public static void RenameDirectories(string www)
        {
            try
            {
                Directory.Move(ToOSPath($"{www}/_framework"), ToOSPath($"{www}/framework"));
            }
            catch (Exception e)
            {
                Logger.Error($"Failed to copy _framework: {e.Message}");
            }
            //try
            //{
            //    Directory.Move(ToOSPath($"{www}/framework/_bin"), ToOSPath($"{www}/framework/bin"));
            //}
            //catch (Exception e)
            //{
            //    Logger.Error($"Failed to copy framework/_bin: {e.Message}");
            //}


            //var contentDir = ToOSPath($"{www}/_content");
            //      if (Directory.Exists(contentDir))
            //      {
            //          Directory.Move(contentDir, ToOSPath($"{www}/content"));
            //      }
            //      else {
            //          Logger.Error($"Failed to copy _content");
            //      }

            // UpdateFile(ToOSPath($"{www}/framework/blazor.server.js"));
            UpdateFile(ToOSPath($"{www}/framework/blazor.webassembly.js"));
            //  UpdateFile(ToOSPath($"{www}/framework/blazor.boot.json"));
            UpdateFile(ToOSPath($"{www}/index.html"));
        }

        public static void UpdateFile(string path)
        {
            try
            {
                var text = File.ReadAllText(path);
                text = text.Replace("_framework", "framework");
                // text = text.Replace("_bin", "bin");
                //  text = text.Replace("_content", "content");
                File.WriteAllText(path, text);
            }
            catch (Exception e)
            {

                Logger.Error($"Failed to uptade file {path}: {e.Message}");
            }

        }
        public static void RemoveFilesByExtension(string path, string extension)
        {

            string[] files = Directory.GetFiles(path, extension);
            foreach (string file in files)
                try
                {
                    File.Delete(file);
                }
                catch (Exception e)
                {
                    Logger.Error($"Failed to remove file {file}: {e.Message}");
                }
            Logger.Success($"Files deleted from {path} with extension: {extension}");

        }

    }
}