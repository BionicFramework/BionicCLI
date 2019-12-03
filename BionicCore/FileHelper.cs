using static BionicCore.DirectoryUtils;
using System;
using System.IO;
using System.Text;

namespace BionicCore {
  public static class FileHelper {
    public static bool FileContains(string path, string match) => File.ReadAllText(path).Contains(match);

    public static int SeekForLineStartingWithAndInsert(string fileName, string startsWith,
      string contentToIntroduce, bool insertAfter = true) {
      var text = new StringBuilder();

      try {
        foreach (var s in File.ReadAllLines(fileName)) {
          text.AppendLine(s.StartsWith(startsWith)
            ? (insertAfter ? $"{s}\n{contentToIntroduce}" : $"{contentToIntroduce}\n{s}")
            : s);
        }

        using (var file = new StreamWriter(File.Create(fileName))) {
          file.Write(text.ToString());
        }
      }
      catch (Exception e) {
        Console.WriteLine($"Failed to read file {fileName}: {e.Message}");
        return 1;
      }

      return 0;
    }

    public static int InsertLast(string filename, string what) {
      var fileList = Directory.GetFiles(ToOSPath("./"), filename, SearchOption.TopDirectoryOnly);
      if (fileList.Length == 0) return 1;
      using (var sw = File.AppendText(fileList[0])) {
        sw.WriteLine(what);
      }

      return 0;
    }
  }
}