using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;
using static System.IO.Path;
using static System.IO.Directory;

namespace BionicCLI.Plugin {
  public static class AssemblyLoader {
    public static Assembly LoadFromAssemblyPath(string assemblyFullPath) {
      var fileNameWithOutExtension = GetFileNameWithoutExtension(assemblyFullPath);
      var fileName = GetFileName(assemblyFullPath);
      var directory = GetDirectoryName(assemblyFullPath);

      var inCompileLibraries = DependencyContext.Default.CompileLibraries.Any(l =>
        l.Name.Equals(fileNameWithOutExtension, StringComparison.OrdinalIgnoreCase));

      var inRuntimeLibraries = DependencyContext.Default.RuntimeLibraries.Any(l =>
        l.Name.Equals(fileNameWithOutExtension, StringComparison.OrdinalIgnoreCase));

      var assembly = (inCompileLibraries || inRuntimeLibraries)
        ? Assembly.Load(new AssemblyName(fileNameWithOutExtension))
        : AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyFullPath);

      if (assembly != null)
        LoadReferencedAssemblies(assembly, fileName, directory);

      return assembly;
    }

    private static void LoadReferencedAssemblies(Assembly assembly, string fileName, string directory) {
      var filesInDirectory = GetFiles(directory).Where(x => x != fileName)
        .Select(GetFileNameWithoutExtension).ToList();
      var references = assembly.GetReferencedAssemblies();

      foreach (var reference in references) {
        if (filesInDirectory.Contains(reference.Name)) {
          var loadFileName = reference.Name + ".dll";
          var path = Combine(directory, loadFileName);
          var loadedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
          if (loadedAssembly != null)
            LoadReferencedAssemblies(loadedAssembly, loadFileName, directory);
        }
      }
    }
  }
}