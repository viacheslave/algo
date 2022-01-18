using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3698/
  /// 
  /// </summary>
  internal class Apr06
  {
    class Solution
    {
      public int MinOperations(int n)
      {
        if (n <= 1)
          return 0;

        var mid = n / 2;
        var ans = 0;

        if (n % 2 == 1)
        {
          for (var i = 0; i < mid; i++)
            ans += 2 * (i + 1);
        }
        else
        {
          for (var i = 0; i < mid; i++)
            ans += 2 * i + 1;
        }

        return ans;
      }
    }
  }
}
