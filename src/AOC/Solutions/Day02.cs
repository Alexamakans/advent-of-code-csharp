using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System;

namespace AOC.Solutions;

public class Day02 : IDay
{
  private readonly List<List<long>> _reports = [];

  public void ProcessLine(string line)
  {
    _reports.Add([.. line.Split(" ").Select(long.Parse)]);
  }

  public long SolvePartOne() { return _reports.Count(IsSafe); }

  public long SolvePartTwo()
  {
    var numSafeReports = 0;
    foreach (var report in _reports)
    {
      if (IsSafe(report))
      {
        numSafeReports++;
        continue;
      }

      for (var i = 0; i < report.Count; i++)
      {
        var clone = new List<long>(report);
        clone.RemoveAt(i);

        if (IsSafe(clone))
        {
          numSafeReports++;
          break;
        }
      }
    }
    return numSafeReports;
  }

  public static bool IsSafe(List<long> report)
  {
    Debug.Assert(report.Count >= 2);

    bool increasing = report[0] < report[1];
    for (var i = 1; i < report.Count; i++)
    {
      var diff = report[i] - report[i - 1];
      if (increasing && (diff < 1 || diff > 3))
      {
        return false;
      }
      if (!increasing && (diff < -3 || diff > -1))
      {
        return false;
      }
    }
    return true;
  }
}
