using System.Collections.Generic;
using System;

using static System.StringSplitOptions;

class Day01 {
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

  public long Solve() {
    _leftList.Sort();
    _rightList.Sort();

    long totalDistance = 0;
    for (var i = 0; i < _leftList.Count; i++) {
      long distance = Math.Abs(_leftList[i] - _rightList[i]);
      totalDistance += distance;
    }

    return totalDistance;
  }
}
