namespace AOC;

using System;
using System.IO;
using System.Reflection;
using System.Linq;

class Program {
  static void Main(string[] args) {
    if (args.Length != 1) {
      var binaryName = AppDomain.CurrentDomain.FriendlyName;
      Console.WriteLine($"Usage: {binaryName} <dayNumber>");
    }
    var inputsDirectory =
        Environment.GetEnvironmentVariable("AOC_CSHARP_2025_INPUT_DIRECTORY") ??
        "/home/alex/dev/advent-of-code-csharp/inputs";

    var dayNumber = Convert.ToInt32(args[0]).ToString("D2");
    var day = NewDay(dayNumber);

    using (var reader =
               new StreamReader(Path.Join(inputsDirectory, dayNumber))) {
      string? line = string.Empty;
      while ((line = reader.ReadLine()) != null) {
        day.ProcessLine(line);
      }
    }

    Console.WriteLine($"Day {dayNumber}:");
    Console.WriteLine($"\tPart One: {day.SolvePartOne()}");
    Console.WriteLine($"\tPart Two: {day.SolvePartTwo()}");
  }

  static Day NewDay(string day) {
    var className = $"Day{day}";
    var assembly = Assembly.GetExecutingAssembly();
    var type = assembly.GetTypes().First(t => t.Name == className);
    if (type == null) {
      throw new NotImplementedException($"Day {day} is not implemented yet");
    }
    return (Day)Activator.CreateInstance(type)!;
  }
}

public interface Day {
  public void ProcessLine(string line);
  public long SolvePartOne();
  public long SolvePartTwo();
}
