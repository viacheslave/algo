using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/611/week-4-july-22nd-july-28th/3823/
  /// 
  /// </summary>
  internal class Jul22
  {
    public class Solution
    {
      public int PartitionDisjoint(int[] A)
      {
        var left = new int[A.Length];
        var right = new int[A.Length];

        int max = int.MinValue;

        for (int i = 0; i < A.Length; i++)
        {
          max = Math.Max(max, A[i]);
          left[i] = max;
        }

        int min = int.MaxValue;
        for (int i = A.Length - 1; i >= 0; i--)
        {
          min = Math.Min(min, A[i]);
          right[i] = min;
        }

        var index = 0;
        while (index < A.Length - 1)
        {
          if (left[index] <= right[index + 1])
            return index + 1;

          index++;
        }

        return -1;
      }
    }
  }
}
