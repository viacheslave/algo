using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/598/week-1-may-1st-may-7th/3731/
  /// 
  /// </summary>
  internal class May04
  {
    public class Solution
    {
      public bool CheckPossibility(int[] nums)
      {
        if (nums.Length < 2)
          return true;

        bool mod = false;

        for (var i = 1; i < nums.Length; i++)
        {
          if (nums[i] < nums[i - 1])
          {
            if (mod)
              return false;

            if (nums[i - 1] > nums[i])
            {
              if (i < 2 || nums[i - 2] <= nums[i])
              {
                nums[i - 1] = nums[i];
                mod = true;
                continue;
              }

              if (i == nums.Length - 1 || nums[i - 1] <= nums[i + 1])
              {
                nums[i] = nums[i - 1];
                mod = true;
                continue;
              }

              return false;
            }
          }
        }


        return true;
      }
    }
  }
}
