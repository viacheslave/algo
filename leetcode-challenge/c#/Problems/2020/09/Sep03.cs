using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/554/week-1-september-1st-september-7th/3447/
  ///    https://leetcode.com/submissions/detail/390358794/?from=/explore/challenge/card/september-leetcoding-challenge/554/week-1-september-1st-september-7th/3447/
  /// </summary>
  internal class Sep03
  {
    public class Solution
    {
      public bool RepeatedSubstringPattern(string s)
      {
        if (s.Length == 1)
          return false;

        for (var l = 0; l < s.Length / 2; l++)
        {
          if ((s.Length) % (l + 1) != 0)
            continue;

          var sindex = 0;

          while (sindex < s.Length)
          {
            if (s[sindex] != s[sindex % (l + 1)])
              break;

            sindex++;
          }

          if (sindex == s.Length)
            return true;
        }

        return false;
      }
    }
  }
}
