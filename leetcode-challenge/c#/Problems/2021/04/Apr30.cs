using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/597/week-5-april-29th-april-30th/3726/
  /// 
  /// </summary>
  internal class Apr30
  {
    public class Solution
    {
      public IList<int> PowerfulIntegers(int x, int y, int bound)
      {
        var hs = new HashSet<int>();

        var ilog = x == 1 ? 0 : (int)Math.Log(bound - 1, x) + 1;
        var jlog = y == 1 ? 0 : (int)Math.Log(bound - 1, y) + 1;

        for (var i = 0; i <= ilog; i++)
        {
          for (var j = 0; j <= jlog; j++)
          {
            var value = (int)Math.Pow(x, i) + (int)Math.Pow(y, j);
            if (value <= bound)
              hs.Add(value);
          }
        }

        return hs.ToArray();
      }
    }
  }
}
