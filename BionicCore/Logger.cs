using System;
using static System.Runtime.InteropServices.OSPlatform;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace BionicCLI {
  public class Logger {
    public static void Log(string msg) => Console.WriteLine(msg);

    public static void NewLine() => Log("");

    public static void Info(string msg) => Log($"{OnWindows("d[ʘ_Ф]b", "🤖")}  {msg}");

    public static void Confirm(string msg) => Log($"{OnWindows(@"d[ʘ_ʘ]b", "👍")}  {msg}");

    public static void Error(string msg) => Log($"{OnWindows(@"¯\(°_o)/¯", "☠")}  {msg}");

    public static void Search(string msg) => Log($"{OnWindows("(⌐ʘ_ʘ)", "🔍")}  {msg}");

    public static void Success(string msg) => Log($"{OnWindows("(⌐■_■)", "🚀")}  {msg}");

    public static void Sorry(string msg) => Log($"{OnWindows(@"\(o_o)/", "😟")}  {msg}");

    public static void Preparing(string msg) => Log($"{OnWindows("c[_]  ", "☕")}  {msg}");

    public static void Task(string msg) => Log($"{OnWindows("√     ", "✔")} {msg}");

    public static void OnSuccessOtherwiseError(bool onSuccess, string success, string error) {
      if (onSuccess) Success(success);
      else Error(error);
    }

    private static string OnWindows(string use, string otherwise) => IsOSPlatform(Windows) ? use : otherwise;
  }
}