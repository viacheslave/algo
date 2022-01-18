using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3713/
  /// 
  /// </summary>
  internal class Apr19
  {
    public class Solution
    {
      public int CombinationSum4(int[] nums, int target)
      {
        Array.Sort(nums);

        var dp = new int[target + 1];
        dp[0] = 1;

        for (int t = 1; t <= target; t++)
        {
          var count = 0;

          for (int c = 0; c < nums.Length; c++)
          {
            var num = nums[c];
            if (t < num)
              break;

            count += dp[t - num];
          }

          dp[t] = count;
        }

        return dp[target];
      }
    }
  }
}
