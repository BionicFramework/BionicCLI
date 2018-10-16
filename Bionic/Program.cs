using System.Collections.Generic;
using System.Linq;
using BionicCLI.Factories;
using McMaster.Extensions.CommandLineUtils;

namespace BionicCLI {
  static class ExtMethods {
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> me) => !me?.Any() ?? true;
  }

  class Program {
    public static int Main(string[] args) {
      BionicCommandFactory.mainArgs = args;
      return CommandLineApplication.Execute<BionicCommandFactory>(args);
    }
  }
}