using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3521/
  ///    
  /// </summary>
  internal class Nov06
  {
    public class Solution
    {
      public int SmallestDivisor(int[] nums, int threshold)
      {
        var upper = 1;
        while (Calc(nums, upper) > threshold)
          upper *= 2;

        if (upper == 1)
          return 1;

        var min = upper / 2;
        var max = upper;

        while (Math.Abs(min - max) > 1)
        {
          var middle = (min + max) / 2;
          if (Calc(nums, middle) > threshold)
            min = middle;
          else
            max = middle;
        }

        if (Calc(nums, max) <= threshold)
          return max;
        return min;
      }

      public long Calc(int[] nums, int cand)
      {
        long sum = 0;
        foreach (var item in nums)
        {
          sum += (int)Math.Ceiling(1.0 * item / cand);
        }
        return sum;
      }
    }
  }
}
