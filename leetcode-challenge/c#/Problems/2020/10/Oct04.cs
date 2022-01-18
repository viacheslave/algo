using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3483/
  ///    https://leetcode.com/submissions/detail/404290702/?from=/explore/challenge/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3483/
  /// </summary>
  internal class Oct04
  {
    public class Solution
    {
      public int RemoveCoveredIntervals(int[][] intervals)
      {
        var ans = new List<int>();

        for (var i = 0; i < intervals.Length; i++)
        {
          for (var j = 0; j < intervals.Length; j++)
          {
            if (i == j)
              continue;

            if (Covered(intervals, i, j))
            {
              ans.Add(i);
              break;
            }
          }
        }

        return intervals.Length - ans.Count;
      }

      private bool Covered(int[][] intervals, int i, int j)
      {
        var th = intervals[i];
        var other = intervals[j];

        return other[0] <= th[0] && th[1] <= other[1];
      }
    }
  }
}
