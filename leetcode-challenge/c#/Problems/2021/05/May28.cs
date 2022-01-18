using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/601/week-4-may-22nd-may-28th/3758/
  /// 
  /// </summary>
  internal class May28
  {
    public class Solution
    {
      public int MaximumUniqueSubarray(int[] nums)
      {
        int l = 0, r = 0;
        var ans = nums[0];
        var sum = nums[0];
        var set = new Dictionary<int, int>() { [nums[0]] = 1 };

        // two-pointers
        while (l < nums.Length && r < nums.Length)
        {
          // shift right unless duplicate is found
          while (r + 1 < nums.Length)
          {
            r++;
            sum += nums[r];

            if (set.ContainsKey(nums[r]))
            {
              set[nums[r]]++;
              break;
            }
            else
            {
              set[nums[r]] = 1;
              ans = Math.Max(ans, sum);
            }
          }

          // shift left unless it's ok again 
          while (l <= r)
          {
            if (set[nums[l]] == 1)
            {
              set.Remove(nums[l]);
              sum -= nums[l];
              l++;
              continue;
            }

            sum -= nums[l];
            set[nums[l]]--;
            l++;
            break;
          }
        }

        return ans;
      }
    }
  }
}
