using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BionicCLI.Factories;
using BionicCore.Project;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils;
using static BionicCore.DirectoryUtils;

namespace BionicCLI.Commands {
  [Command(Description = "Execute Bionic Blast scripts")]
  public class BlastCommand : CommandBase, ICommand {
    private static readonly string BlastFile = ToOSPath(".bionic/bionic.blast");

    [Argument(0, Description = "Target script to execute"), Required]
    private string Target { get; set; }

    protected override int OnExecute(CommandLineApplication app) => ExecuteBlasterScript();

    public int Execute() => ExecuteBlasterScript();
    
    public BionicCommandFactory Parent { get; }

    private int ExecuteBlasterScript() {
      var cd = Directory.GetCurrentDirectory();
      if (!File.Exists(ToOSPath($"{cd}/{BlastFile}"))) {
        Logger.Error($"Could not find {BlastFile} in current directory. Are you in a Blazor Standalone or Client project directory?");
        return 1;
      }

      try {
        var model = BuildBlastingModel(ToOSPath($"{cd}/{BlastFile}"));
        RunScript(Target, model);
      }
      catch (Exception e) {
        Logger.Error(e.Message);
        return 1;
      }

      Logger.Success("Blasting complete!");

      return 0;
    }

    private static bool RunScript(string target, Dictionary<string, IList<string>> model) {
      var t = $":{target}";
      var cmds = new List<string>();
      if (model.Keys.Contains(t)) {

        var targetCmds = model[t];
        model.Remove(t);
        BuildCommandList(cmds, targetCmds, model); // TODO: Create stack execution machine for improved sub-target sharing 
        
        cmds.ForEach(cmd => {
          Logger.Task($"Executing: {cmd}");
          // TODO: introduce "interactive" option and allow user to decide to continue or stop scripts in the case
          // of a non-zero return code.
          RunProcess(cmd);
        });

        return true;
      }
      
      Logger.Error($"Can't zap! Blast script {target} not available. Check your {BlastFile} for possible issues");
      return false;
    }

    private static void BuildCommandList(ICollection<string> cmds, ICollection<string> targetCmds, IReadOnlyDictionary<string, IList<string>> model) {
      foreach (var cmd in targetCmds) {
        if (cmd.StartsWith(":")) {
          if (model.ContainsKey(cmd)) {
            BuildCommandList(cmds, model[cmd], model);
          }
          else {
            throw new Exception("Can't zap! Blast script sub-target {cmd} not available or already processed. Processed commands are removed to avoid cyclic references.");
          }
        }
        else {
          cmds.Add(cmd);
        }
      }
      targetCmds.Clear();
    }

    private static int RunProcess(string cmd) {
      var cmds = cmd.Split(new [] { ' ' }, 2);
      Process process = null;
      try {
        process = Process.Start(
          new ProcessStartInfo(cmds[0], cmds[1]) {
            UseShellExecute = false
          }
        );
        process?.WaitForExit();
      }
      catch (Exception e) {
        Logger.Error($"Failed to execute command \"{cmds[0]} {cmds[1]}\": {e.Message}");
      }

      return process?.ExitCode ?? 1;
    }
    
    private static Dictionary<string, IList<string>> BuildBlastingModel(string path) {
      var lines = File.ReadLines(path);
      var model = new Dictionary<string, IList<string>>();
      var currentCmds = new List<string>();
      foreach (var line in lines) {
        var entry = line.Trim();
        if (entry.StartsWith(":")) {
          currentCmds = new List<string>();
          model.Add(entry, currentCmds);
        } else if (entry.StartsWith(">")) {
          currentCmds.Add($":{entry.Substring(1)}");
        } else if (!entry.IsNullOrEmpty()) {
          currentCmds.Add(entry);
        }
      }

      return model;
    }
  }
}