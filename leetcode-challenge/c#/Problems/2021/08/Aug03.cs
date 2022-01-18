using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3836/
  /// 
  /// </summary>
  internal class Aug03
  {
    public class Solution
    {
      public int[] TwoSum(int[] nums, int target)
      {
        for (int i = 0; i < nums.Length; i++)
          for (int j = i + 1; j < nums.Length; j++)
          {
            if (nums[i] + nums[j] == target)
              return new int[] { i, j };
          }

        return new int[0];
      }
    }
  }
}
