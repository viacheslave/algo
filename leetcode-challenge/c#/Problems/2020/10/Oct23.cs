using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3505/
  ///    https://leetcode.com/submissions/detail/412192679/?from=/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3505/
  /// </summary>
  internal class Oct23
  {
    public class Solution
    {
      public bool Find132pattern(int[] nums)
      {
        if (nums.Length < 3)
          return false;

        var leftmin = nums[0];

        for (var i = 1; i < nums.Length - 1; ++i)
        {
          var current = nums[i];

          if (current < leftmin)
          {
            leftmin = current;
            continue;
          }

          for (var j = i + 1; j < nums.Length; ++j)
          {
            if (nums[j] < current && nums[j] > leftmin)
              return true;
          }
        }

        return false;
      }
    }
  }
}
