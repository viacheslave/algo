using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/missing-number-in-arithmetic-progression/
  ///    Submission: https://leetcode.com/submissions/detail/450714191/
  ///    Audible
  /// </summary>
  internal class P1228
  {
    public class Solution
    {
      public int MissingNumber(int[] arr)
      {
        var diffs = new List<(int, int, int)>();

        for (var i = 1; i < arr.Length; i++)
        {
          diffs.Add((arr[i], arr[i - 1], arr[i] - arr[i - 1]));
        }

        var maxDiff = diffs.Max(c => Math.Abs(c.Item3));
        var maxEls = diffs.Where(c => Math.Abs(c.Item3) == maxDiff).First();

        return (maxEls.Item1 + maxEls.Item2) / 2;
      }
    }
  }
}
