using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3652/
  ///   
  /// </summary>
  internal class Feb25
  {
    public class Solution
    {
      public int FindUnsortedSubarray(int[] nums)
      {
        var copy = new int[nums.Length];
        nums.CopyTo(copy, 0);
        Array.Sort(copy);

        var start = -1;
        var end = copy.Length;

        for (var i = 0; i < copy.Length; i++)
          if (nums[i] != copy[i])
          {
            start = i;
            break;
          }

        for (var i = copy.Length - 1; i >= 0; i--)
          if (nums[i] != copy[i])
          {
            end = i;
            break;
          }

        if (end <= start)
          return 0;

        if (end == copy.Length || start == -1)
          return 0;

        return end - start + 1;
      }
    }
  }
}
