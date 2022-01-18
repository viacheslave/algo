using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/586/week-3-february-15th-february-21st/3641/
  ///    
  /// </summary>
  internal class Feb15
  {
    public class Solution
    {
      public int[] KWeakestRows(int[][] mat, int k)
      {
        return mat.Select((row, index) => (index, row.Count(r => r == 1)))
            .OrderBy(x => x.Item2)
            .ThenBy(x => x.index)
            .Take(k)
            .Select(x => x.index)
            .ToArray();
      }
    }
  }
}
