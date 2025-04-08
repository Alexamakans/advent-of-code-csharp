namespace AOC.Solutions;

using System.Collections.Generic;
using System.Linq;
using System;

using static System.StringSplitOptions;

public class Day01 : IDay
{
  private readonly List<long> _leftList = [];
  private readonly List<long> _rightList = [];

  public void ProcessLine(string line)
  {
    var (left, right) = line.Split(" ",
                                   TrimEntries | RemoveEmptyEntries) switch
    {
      [var l, var r] => (long.Parse(l), long.Parse(r)),
      _ => throw new FormatException("Expected exactly two values in line")
    };
    _leftList.Add(left);
    _rightList.Add(right);
  }

  public long SolvePartOne()
  {
    _leftList.Sort();
    _rightList.Sort();

    long totalDistance = 0;
    for (var i = 0; i < _leftList.Count; i++)
    {
      long distance = Math.Abs(_leftList[i] - _rightList[i]);
      totalDistance += distance;
    }

    return totalDistance;
  }

  public long SolvePartTwo()
  {
    long similarity = 0;
    foreach (var value in _leftList)
    {
      long occurrences = _rightList.Where(e => value == e).Count();
      similarity += value * occurrences;
    }
    return similarity;
  }
}
