namespace AOC.Solutions;

using System.Collections.Generic;
using System.Linq;
using System;

using static System.StringSplitOptions;

class Day01 : Day {
  private List<long> _leftList = new List<long>();
  private List<long> _rightList = new List<long>();

  public void ProcessLine(string line) {
    var (left, right) = line.Split(" ",
                                   TrimEntries | RemoveEmptyEntries) switch {
      [var l, var r] => (Convert.ToInt64(l), Convert.ToInt64(r)),
      _ => throw new FormatException("Expected exactly two values in line")
    };
    _leftList.Add(left);
    _rightList.Add(right);
  }

  public long SolvePartOne() {
    _leftList.Sort();
    _rightList.Sort();

    long totalDistance = 0;
    for (var i = 0; i < _leftList.Count; i++) {
      long distance = Math.Abs(_leftList[i] - _rightList[i]);
      totalDistance += distance;
    }

    return totalDistance;
  }

  public long SolvePartTwo() {
    long similarity = 0;
    foreach (var value in _leftList) {
      long occurrences = _rightList.Where(e => value == e).Count();
      similarity += value * occurrences;
    }
    return similarity;
  }
}
