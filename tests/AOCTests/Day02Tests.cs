namespace AOCTests;

using AOC.Solutions;
using System.IO;
using Xunit;

public class Day02Test
{
  readonly string sample = @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";

  [Fact]
  public void Day02_PartOne_GivenSample_ReturnsCorrectAnswer()
  {
    var day = new Day02();
    using (var reader = new StringReader(sample))
    {
      Util.ProcessInput(day, reader);
    }

    Assert.Equal(2, day.SolvePartOne());
  }

  [Fact]
  public void Day02_PartTwo_GivenSample_ReturnsCorrectAnswer()
  {
    var day = new Day02();
    using (var reader = new StringReader(sample))
    {
      Util.ProcessInput(day, reader);
    }

    Assert.Equal(4, day.SolvePartTwo());
  }
}
