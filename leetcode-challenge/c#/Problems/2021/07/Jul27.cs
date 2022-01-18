using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/611/week-4-july-22nd-july-28th/3828/
  /// 
  /// </summary>
  internal class Jul27
  {
    public class Solution
    {
      public int ThreeSumClosest(int[] nums, int target)
      {
        var interval = int.MaxValue;
        var sum = int.MinValue;

        Array.Sort(nums);

        for (var i = 0; i < nums.Length - 2; i++)
        {
          var j = i + 1;
          var k = nums.Length - 1;

          while (j < k)
          {
            if (nums[i] + nums[j] + nums[k] == target)
              return nums[i] + nums[j] + nums[k];

            if (nums[i] + nums[j] + nums[k] < target)
            {
              if (Math.Abs(target - (nums[i] + nums[j] + nums[k])) < interval)
              {
                interval = Math.Abs(target - (nums[i] + nums[j] + nums[k]));
                sum = nums[i] + nums[j] + nums[k];
              }

              j++; continue;
            }

            if (nums[i] + nums[j] + nums[k] > target)
            {
              if (Math.Abs(target - (nums[i] + nums[j] + nums[k])) < interval)
              {
                interval = Math.Abs(target - (nums[i] + nums[j] + nums[k]));
                sum = nums[i] + nums[j] + nums[k];
              }

              k--; continue;
            }

            while (k - 1 >= 0 && nums[k - 1] == nums[k])
              k--;

            while (j + 1 < nums.Length && nums[j + 1] == nums[j])
              j++;

            k--; j++;
          }

          while (i + 1 < nums.Length && nums[i + 1] == nums[i])
            i++;
        }

        return sum;
      }
    }
  }
}
