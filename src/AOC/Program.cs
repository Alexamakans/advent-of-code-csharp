namespace AOC;

using System;
using System.IO;

class Program {
  static void Main(string[] args) {
    var inputsDirectory = System.Environment.GetEnvironmentVariable(
                              "AOC_CSHARP_2025_INPUT_DIRECTORY") ??
                          "/home/alex/dev/advent-of-code-csharp/inputs";

    var day = new Day01();
    using (var reader =
               new StreamReader(System.IO.Path.Join(inputsDirectory, "1"))) {
      string? line = string.Empty;
      while ((line = reader.ReadLine()) != null) {
        day.ProcessLine(line);
      }
    }

    var result = day.Solve();
    Console.WriteLine($"Result: {result}");
  }
}
