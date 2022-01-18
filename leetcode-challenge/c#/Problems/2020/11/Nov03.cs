using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3518/
  ///    https://leetcode.com/submissions/detail/416308250/?from=/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3518/
  /// </summary>
  internal class Nov03
  {
    public class Solution
    {
      public int MaxPower(string s)
      {
        if (s.Length == 0)
          return 0;

        if (s.Length == 1)
          return 1;

        var current = 1;
        var ans = current;

        for (var i = 1; i < s.Length; i++)
        {
          if (s[i] == s[i - 1])
          {
            current++;
          }
          else
          {
            ans = Math.Max(ans, current);
            current = 1;
          }
        }

        ans = Math.Max(ans, current);
        return ans;
      }
    }
  }
}
