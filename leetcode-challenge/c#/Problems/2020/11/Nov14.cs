using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3530/
  ///    
  /// </summary>
  internal class Nov14
  {
    public class Solution
    {
      public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
      {
        var t = minutesToTest / minutesToDie + 1;

        var exp = 0;
        for (; ; )
        {
          var pow = (int)Math.Pow(t, exp);
          if (pow >= buckets)
            return exp;

          exp++;
        }
      }
    }
  }
}
