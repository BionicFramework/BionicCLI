using System;
using System.IO;
using System.Text;

namespace Bionic.Utils {
  public class FileHelper {
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
  }
}