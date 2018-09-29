using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Bionic.Utils {
  public class UrlHelper {
    public static Process OpenUrl(string url) {
      try {
        return Process.Start(url);
      }
      catch {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
          url = url.Replace("&", "^&");
          return Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") {CreateNoWindow = true});
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
          return Process.Start("xdg-open", url);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
          return Process.Start("open", url);
        }
      }

      return null;
    }
  }
}