using System;

namespace BionicCLI {
  public class Logger {
    public static void Log(string msg) => Console.WriteLine(msg);

    public static void NewLine() => Log("");

    public static void Info(string msg) => Log($"🤖  {msg}");

    public static void Confirm(string msg) => Log($"👍  {msg}");

    public static void Error(string msg) => Log($"☠  {msg}");

    public static void Search(string msg) => Log($"🔍  {msg}");

    public static void Success(string msg) => Log($"🚀  {msg}");

    public static void Sorry(string msg) => Log($"😟  {msg}");

    public static void Preparing(string msg) => Log($"☕  {msg}");

    public static void Task(string msg) => Log($"✔ {msg}");

    public static void OnSuccessOtherwiseError(bool onSuccess, string success, string error) {
      if (onSuccess) Success(success);
      else Error(error);
    }
  }
}