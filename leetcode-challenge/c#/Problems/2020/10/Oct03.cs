using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3482/
  ///		
  /// </summary>
  internal class Oct03
  {
    public class Solution
    {
      public int FindPairs(int[] nums, int k)
      {
        if (nums.Length <= 1)
          return 0;

        Array.Sort(nums);

        var hs = new HashSet<(int, int)>();

        for (var i = 0; i < nums.Length; i++)
        {
          for (var j = i + 1; j < nums.Length; j++)
          {
            if (nums[j] - nums[i] < k)
              continue;

            if (nums[j] - nums[i] == k)
            {
              hs.Add((nums[i], nums[j]));
              continue;
            }

            if (nums[j] - nums[i] > k)
              break;
          }
        }

        return hs.Count;
      }
    }
  }
}
