using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/610/week-3-july-15th-july-21st/3815/
  /// 
  /// </summary>
  internal class Jul15
  {
    public class Solution
    {
      public int TriangleNumber(int[] nums)
      {
        if (nums.Length < 3)
          return 0;

        Array.Sort(nums);

        var count = 0;

        for (var i = 0; i < nums.Length - 2; i++)
        {
          for (var j = i + 1; j < nums.Length - 1; j++)
          {
            for (var k = j + 1; k < nums.Length; k++)
            {
              if (nums[k] >= nums[i] + nums[j])
                break;

              count++;
            }
          }
        }

        return count;
      }
    }
  }
}
