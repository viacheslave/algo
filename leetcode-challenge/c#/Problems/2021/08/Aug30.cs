using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/617/week-5-august-29th-august-31st/3957/
  /// 
  /// </summary>
  internal class Aug30
  {
    public class Solution
    {
      public int MaxCount(int m, int n, int[][] ops)
      {
        var minX = m;
        var minY = n;

        var count = 0;

        foreach (var op in ops)
        {
          if (op[0] < minX) minX = op[0];
          if (op[1] < minY) minY = op[1];

          count++;
        }

        return minX * minY;
      }
    }
  }
}
