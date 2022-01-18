using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3459/
  ///    https://leetcode.com/submissions/detail/395483495/?from=/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3459/
  /// </summary>
  internal class Sep14
  {
    public class Solution
    {
      public int Rob(int[] nums)
      {
        var max = 0;

        var dp = new Dictionary<int, int>();
        dp[-1] = 0;
        dp[-2] = 0;
        dp[-3] = 0;

        for (int i = 0; i < nums.Length; i++)
        {
          dp[i] = nums[i] + Math.Max(dp[i - 2], dp[i - 3]);
          max = Math.Max(max, dp[i]);
        }

        return max;
      }
    }
  }
}
