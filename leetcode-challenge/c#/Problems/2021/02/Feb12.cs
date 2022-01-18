using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/585/week-2-february-8th-february-14th/3637/
  ///    
  /// </summary>
  internal class Feb12
  {
    public class Solution
    {
      public int NumberOfSteps(int num)
      {
        var ans = 0;
        while (num > 0)
        {
          if (num % 2 == 0)
          {
            num >>= 1;
          }
          else
          {
            num -= 1;
          }
          ans++;
        }
        return ans;
      }
    }
  }
}
