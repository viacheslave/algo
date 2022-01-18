using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.September.Challenge.Problems
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/557/week-4-september-22nd-september-28th/3475/
  ///		
  /// </summary>
  internal class Sep28
  {
    public class Solution
    {
      public int NumSubarrayProductLessThanK(int[] nums, int k)
      {
        var ans = 0;

        var j = 0;

        int product = 1;

        for (int i = 0; i < nums.Length; i++)
        {
          product = product * nums[i];

          if (i == 0)
          {
            if (product < k)
              ans++;

            continue;
          }

          while (product >= k && j <= i)
          {
            product = product / nums[j];
            j++;
          }

          ans += (i - j + 1);
        }

        return ans;
      }
    }
  }
}
