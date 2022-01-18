using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3520/
  ///    https://leetcode.com/submissions/detail/417007116/?from=/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3520/
  /// </summary>
  internal class Nov05
  {
    public class Solution
    {
      public int MinCostToMoveChips(int[] chips)
      {
        var oddSum = chips.Count(c => c % 2 == 1);
        var evenSum = chips.Count(c => c % 2 == 0);

        if (oddSum == 0 || evenSum == 0)
          return 0;

        return Math.Min(evenSum, oddSum);
      }
    }
  }
}
