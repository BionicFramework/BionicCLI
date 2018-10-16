using System.Diagnostics;
using static System.Runtime.InteropServices.OSPlatform;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace BionicCore {
  public static class BrowserUtils {
    public static Process OpenUrl(string url) {
      try {
        return Process.Start(url);
      }
      catch {
        if (IsOSPlatform(Windows)) {
          url = url.Replace("&", "^&");
          return Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") {CreateNoWindow = true});
        }

        if (IsOSPlatform(Linux)) {
          return Process.Start("xdg-open", url);
        }

        if (IsOSPlatform(OSX)) {
          return Process.Start("open", url);
        }
      }

      return null;
    }
  }
}