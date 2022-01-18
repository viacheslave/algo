using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3567/
  ///    https://leetcode.com/submissions/detail/430864915/?from=explore&item_id=3567
  /// </summary>
  internal class Dec15
  {
    public class Solution
    {
      public int[] SortedSquares(int[] A)
      {
        if (A.Length == 0)
          return A;

        if (A.Length == 1)
          return new int[] { A[0] * A[0] };

        var result = new int[A.Length];

        int index = A.Length - 1;

        int left = 0;
        int right = A.Length - 1;

        while (left <= right)
        {
          if (left == right)
          {
            result[index] = A[left] * A[left];
            left++;
            continue;
          }

          if (A[left] * A[left] == A[right] * A[right])
          {
            result[index] = A[left] * A[left];
            result[index - 1] = A[right] * A[right];
            index = index - 2;
            left++;
            right--;
            continue;
          }

          if (A[left] * A[left] < A[right] * A[right])
          {
            // insert right
            result[index] = A[right] * A[right];
            index--;
            right--;
            continue;
          }

          if (A[left] * A[left] > A[right] * A[right])
          {
            // insert left
            result[index] = A[left] * A[left];
            index--;
            left++;
            continue;
          }
        }

        return result;
      }
    }
  }
}
