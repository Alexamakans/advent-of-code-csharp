namespace AOCTests;

using AOC;

static class Util
{
  internal static void ProcessInput(IDay day, StringReader reader)
  {
    string? line;
    while ((line = reader.ReadLine()) != null)
    {
      day.ProcessLine(line);
    }
  }
}
