using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3658/
  /// 
  /// </summary>
  internal class Mar02
  {
    public class Solution
    {
      public int[] FindErrorNums(int[] nums)
      {
        if (nums.Length < 2)
          return new int[0];

        var expSum = (nums.Length * (nums.Length + 1)) / 2;

        var sum = 0;
        var hs = new HashSet<int>();
        var dup = 0;

        foreach (var s in nums)
        {
          sum += s;
          if (hs.Contains(s))
          {
            dup = s;
          }
          else
          {
            hs.Add(s);
          }
        }

        var diff = expSum - sum;

        return new int[] { dup, dup + diff };
      }
    }
  }
}
