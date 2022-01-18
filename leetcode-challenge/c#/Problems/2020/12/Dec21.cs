using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3573/
  ///    https://leetcode.com/submissions/detail/432928793/?from=explore&item_id=3573
  /// </summary>
  internal class Dec21
  {
    public class Solution
    {
      public int SmallestRangeII(int[] A, int K)
      {
        if (A.Length == 0)
          return 0;

        Array.Sort(A);

        var ans = A[^1] - A[0];

        for (int i = 0; i < A.Length - 1; i++)
        {
          var min = Math.Min(A[i + 1] - K, A[0] + K);
          var max = Math.Max(A[i] + K, A[^1] - K);

          ans = Math.Min(ans, Math.Abs(max - min));
        }

        return ans;
      }
    }
  }
}
