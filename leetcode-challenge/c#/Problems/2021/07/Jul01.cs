using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/july-leetcoding-challenge-2021/608/week-1-july-1st-july-7th/3799/
  /// 
  /// </summary>
  internal class Jul01
  {
    public class Solution
    {
      public IList<int> GrayCode(int n)
      {
        var res = new List<int>();

        for (var i = 0; i < (int)Math.Pow(2, n); i++)
          res.Add(Get(i, n));

        return res;
      }

      private int Get(int n, int l)
      {
        var res = 0;

        for (var col = 0; col < l; col++)
        {
          var colLength = Math.Pow(2, col + 1);
          var index = n % colLength;

          var value = 0;
          if (index > colLength / 2 - 1)
            value = 1;


          var largeIndex = n % (colLength * 2);
          if (largeIndex >= colLength)
            value = 1 - value;

          if (value > 0)
            res += (int)Math.Pow(2, col);
        }

        return res;

      }
    }
  }
}
