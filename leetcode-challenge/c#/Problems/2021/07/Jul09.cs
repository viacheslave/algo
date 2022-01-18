using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/609/week-2-july-8th-july-14th/3808/
  /// 
  /// </summary>
  internal class Jul09
  {
    public class Solution
    {
      public int LengthOfLIS(int[] nums)
      {
        var dp = Enumerable.Repeat(1, nums.Length).ToArray();

        for (var i = 1; i < nums.Length; i++)
          for (var j = 0; j < i; j++)
            if (nums[i] > nums[j] && dp[i] < dp[j] + 1)
              dp[i] = dp[j] + 1;

        return dp.Max();
      }
    }
  }
}
