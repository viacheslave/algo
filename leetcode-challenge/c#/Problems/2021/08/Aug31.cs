using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/617/week-5-august-29th-august-31st/3958/
  /// 
  /// </summary>
  internal class Aug31
  {
    public class Solution
    {
      public int FindMin(int[] nums)
      {
        if (nums.Length == 1)
          return nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
          if (nums[i] < nums[i - 1])
            return nums[i];
        }

        return nums[0];
      }
    }
  }
}
