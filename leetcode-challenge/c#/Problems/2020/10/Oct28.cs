using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3510/
  ///    https://leetcode.com/submissions/detail/414085104/?from=/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3510/
  /// </summary>
  internal class Oct28
  {
    public class Solution
    {
      public IList<string> SummaryRanges(int[] nums)
      {
        var result = new List<string>();
        if (nums.Length == 0)
          return result;

        if (nums.Length == 1)
          return new List<string>() { nums[0].ToString() };

        var start = -1;
        var end = -1;

        for (int i = 0; i < nums.Length; i++)
        {
          if (start == -1)
          {
            start = i;
            end = i;
            continue;
          }

          if (nums[i] - nums[i - 1] != 1)
          {
            if (end == start)
              result.Add(nums[start].ToString());
            else
              result.Add($"{nums[start]}->{nums[end]}");

            start = i;
            end = i;
          }

          if (nums[i] - nums[i - 1] == 1)
          {
            end = i;
          }

          if (i == nums.Length - 1)
          {
            if (end == start)
              result.Add(nums[start].ToString());
            else
              result.Add($"{nums[start]}->{nums[end]}");
          }
        }

        return result;
      }
    }
  }
}
