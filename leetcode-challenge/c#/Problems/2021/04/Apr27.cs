using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3722/
  /// 
  /// </summary>
  internal class Apr27
  {
    public class Solution
    {
      public bool IsPowerOfThree(int n)
      {
        if (n <= 0)
          return false;

        if (n == 1)
          return true;

        while (n > 0)
        {
          if (n % 3 != 0)
            return false;

          n = n / 3;

          if (n == 1)
            return true;
        }

        return true;
      }
    }
  }
}
