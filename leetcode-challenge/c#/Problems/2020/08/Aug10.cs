using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th/3419/
  ///    https://leetcode.com/submissions/detail/378799455/?from=/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3419/
  /// </summary>
  internal class Aug10
  {
    public class Solution
    {
      public int TitleToNumber(string s)
      {
        if (s.Length == 0)
          return 0;

        int sum = 0;
        for (var i = 0; i < s.Length; i++)
        {
          var ch = s[i];
          var power = s.Length - i;

          sum += ((int)ch - 65 + 1) * (int)Math.Pow(26, power - 1);
        }

        return sum;
      }
    }
  }
}
