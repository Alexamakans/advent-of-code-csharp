namespace AOCTests;

using AOC.Solutions;
using System.IO;
using Xunit;

public class Day01Test
{
  readonly string sample = @"3   4
4   3
2   5
1   3
3   9
3   3";

  [Fact]
  public void Day01_PartOne_GivenSample_ReturnsCorrectAnswer()
  {
    var day = new Day01();
    using (var reader = new StringReader(sample))
    {
      Util.ProcessInput(day, reader);
    }

    Assert.Equal(11, day.SolvePartOne());
  }

  [Fact]
  public void Day01_PartTwo_GivenSample_ReturnsCorrectAnswer()
  {
    var day = new Day01();
    using (var reader = new StringReader(sample))
    {
      Util.ProcessInput(day, reader);
    }

    Assert.Equal(31, day.SolvePartTwo());
  }
}
