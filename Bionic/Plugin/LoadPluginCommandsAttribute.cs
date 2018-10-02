using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Bionic.Project;
using BionicPlugin;
using McMaster.Extensions.CommandLineUtils.Conventions;

namespace Bionic.Plugin {
  [AttributeUsage(AttributeTargets.Class)]
  internal class LoadPluginCommandsAttribute : Attribute, IConvention {
    public void Apply(ConventionContext context) {
      context.Application.Description = "This command is defined in " + context.ModelType.Assembly.FullName;

      if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/.bionic") ||
          !ProjectHelper.InClientOrStandaloneDir()) return;

      var plugins = Directory.GetDirectories($"{Directory.GetCurrentDirectory()}/.bionic", "Bionic*Plugin");
      foreach (var path in plugins) {
        var fp = $"{path}/lib/netcoreapp2.1/{new DirectoryInfo(path).Name}.dll";
        var a = AssemblyLoader.LoadFromAssemblyPath(fp);

        IList<Type> commandPluginTypes = (
          from t in a.GetTypes()
          where t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(ICommandPlugin))
          select t
        ).ToList();

        foreach (var commandPluginType in commandPluginTypes) {
          var name = commandPluginType.Name;
          var plugin = (ICommandPlugin) commandPluginType.Assembly.CreateInstance(commandPluginType.FullName);
          context.Application.Command(plugin.CommandName, cmd => { plugin.Initialize(cmd); });
        }
      }
    }
  }
}