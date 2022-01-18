using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/603/week-1-june-1st-june-7th/3766/
  /// 
  /// </summary>
  internal class Jun03
  {
    public class Solution
    {
      public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
      {
        var yarr = new List<int>(horizontalCuts);
        yarr.Add(0);
        yarr.Add(h);

        var xarr = new List<int>(verticalCuts);
        xarr.Add(0);
        xarr.Add(w);

        yarr.Sort();
        xarr.Sort();

        var maxdiff_y = int.MinValue;
        for (int i = 1; i < yarr.Count; i++)
          maxdiff_y = Math.Max(yarr[i] - yarr[i - 1], maxdiff_y);

        var maxdiff_x = int.MinValue;
        for (int i = 1; i < xarr.Count; i++)
          maxdiff_x = Math.Max(xarr[i] - xarr[i - 1], maxdiff_x);

        return (int)(((long)maxdiff_x * (long)maxdiff_y) % 1_000_000_007);
      }
    }
  }
}
