using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3533/
  ///    https://leetcode.com/submissions/detail/420813204/?from=/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3533/
  /// </summary>
  internal class Nov16
  {
    public class Solution
    {
      public int LongestMountain(int[] A)
      {
        var max = 0;

        for (int i = 1; i < A.Length - 1; i++)
        {
          var left = i - 1;
          var right = i + 1;

          while (left >= 0 && A[left] < A[left + 1])
            left--;

          while (right < A.Length && A[right] < A[right - 1])
            right++;

          if (left == i - 1 || right == i + 1)
            continue;

          max = Math.Max(max, right - left - 1);
        }

        return max;
      }
    }
  }
}
