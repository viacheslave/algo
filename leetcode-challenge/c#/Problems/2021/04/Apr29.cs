using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/597/week-5-april-29th-april-30th/3725/
  /// 
  /// </summary>
  internal class Apr29
  {
    public class Solution
    {
      public int[] SearchRange(int[] nums, int target)
      {
        int min = -1;
        int max = -1;

        for (var i = 0; i < nums.Length; i++)
        {
          if (nums[i] == target && min == -1)
          {
            min = i;
            max = i;
            continue;
          }

          if (nums[i] == target)
          {
            max = i;
          }
        }

        return new int[] { min, max };
      }
    }
  }
}
