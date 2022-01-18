using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/560/week-2-october-8th-october-14th/3494/
  ///		
  /// </summary>
  internal class Oct14
  {
    public class Solution
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            
            return Math.Max(
                RobInternal(nums.Take(nums.Length - 1).ToList()),
                RobInternal(nums.Skip(1).Take(nums.Length - 1).ToList())
            );
        }

        public int RobInternal(List<int> nums)
        {
            var max = 0;

            var dp = new Dictionary<int, int>();
            dp[-1] = 0;
            dp[-2] = 0;
            dp[-3] = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                dp[i] = nums[i] + Math.Max(dp[i - 2], dp[i - 3]);
                max = Math.Max(max, dp[i]);
            }

            return max;
        }
    }
  }
}
