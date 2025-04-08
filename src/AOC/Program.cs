namespace AOC;

using System;
using System.IO;
using System.Reflection;
using System.Linq;

class Program
{
  static void Main(string[] args)
  {
    if (args.Length != 1)
    {
      var binaryName = AppDomain.CurrentDomain.FriendlyName;
      Console.WriteLine($"Usage: {binaryName} <dayNumber>");
    }
    var inputsDirectory =
        Environment.GetEnvironmentVariable("AOC_CSHARP_2025_INPUT_DIRECTORY") ??
        "/home/alex/dev/advent-of-code-csharp/inputs";

    if (!int.TryParse(args[0], out int dayNumber))
    {
      var binaryName = AppDomain.CurrentDomain.FriendlyName;
      Console.WriteLine($"Invalid day number: {args[0]}");
      Console.WriteLine($"Usage: {binaryName} <dayNumber>");
      Environment.Exit(2);
    }
    var dayNumberString = dayNumber.ToString("D2");
    var day = NewDay(dayNumberString);

    using (var reader =
               new StreamReader(Path.Join(inputsDirectory, dayNumberString)))
    {
      string? line = string.Empty;
      while ((line = reader.ReadLine()) != null)
      {
        day.ProcessLine(line);
      }
    }

    Console.WriteLine($"Day {dayNumberString}:");
    Console.WriteLine($"\tPart One: {day.SolvePartOne()}");
    Console.WriteLine($"\tPart Two: {day.SolvePartTwo()}");
  }

  static IDay NewDay(string day)
  {
    var className = $"Day{day}";
    var assembly = Assembly.GetExecutingAssembly();
    var type =
        assembly.GetTypes().First(t => t.Name == className) ??
        throw new NotImplementedException($"Day {day} is not implemented yet");
    return (IDay)Activator.CreateInstance(type)!;
  }
}

public interface IDay
{
  public void ProcessLine(string line);
  public long SolvePartOne();
  public long SolvePartTwo();
}
