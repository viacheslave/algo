using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/similar-rgb-color/
  ///    Submission: https://leetcode.com/submissions/detail/451487763/
  ///    Google
  /// </summary>
  internal class P0800
  {
    public class Solution
    {
      public string SimilarRGB(string color)
      {
        var bytes = new List<int>
        {
          Convert.ToInt32(color.Substring(1, 2), 16),
          Convert.ToInt32(color.Substring(3, 2), 16),
          Convert.ToInt32(color.Substring(5, 2), 16)
        };

        var list = new List<int>();

        foreach (var @byte in bytes)
        {
          var min = int.MaxValue;
          var closest = 0;

          for (var i = 0; i < 16; i++)
          {
            var value = 16 * i + i;

            if (min > Math.Abs(value - @byte))
            {
              min = Math.Min(min, Math.Abs(value - @byte));
              closest = value;
            }
          }

          list.Add(closest);
        }

        return "#" + $"{list[0]:X2}{list[1]:X2}{list[2]:X2}".ToLower();
      }
    }
  }
}
