using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3545/
  ///    https://leetcode.com/submissions/detail/424588775/?from=/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3545/
  /// </summary>
  internal class Nov27
  {
    public class Solution
    {
      public bool CanPartition(int[] nums)
      {
        int sum = nums.Sum();
        if (sum % 2 == 1)
          return false;

        var target = sum / 2;
        Array.Sort(nums);

        var dp = new HashSet<int> { nums[0] };

        for (var i = 1; i < nums.Length; i++)
        {
          foreach (var item in dp.ToArray())
          {
            var value = item + nums[i];

            if (value == target) return true;
            if (value > target)
              continue;

            dp.Add(value);
          }

          if (nums[i] == target) return true;
          if (nums[i] < target)
            dp.Add(nums[i]);
        }

        return false;
      }
    }
  }
}
