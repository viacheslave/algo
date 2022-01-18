using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/605/week-3-june-15th-june-21st/3782/
  /// 
  /// </summary>
  internal class Jun17
  {
    public class Solution
    {
      public int NumSubarrayBoundedMax(int[] A, int L, int R)
      {
        var dp = new Dictionary<int, int>[A.Length];

        dp[0] = new Dictionary<int, int>();

        if (A[0] <= R)
          dp[0][A[0]] = 1;

        for (var i = 1; i < A.Length; ++i)
        {
          dp[i] = new Dictionary<int, int>();

          if (A[i] <= R)
            dp[i][A[i]] = 1;

          foreach (var entry in dp[i - 1])
          {
            var max = entry.Key;
            var newmax = Math.Max(entry.Key, A[i]);

            if (newmax <= R)
            {
              if (!dp[i].ContainsKey(newmax))
                dp[i][newmax] = 0;

              dp[i][newmax] += entry.Value;
            }
          }
        }

        return dp
          .SelectMany(x => x)
          .Where(c => L <= c.Key && c.Key <= R)
          .Sum(x => x.Value);
      }
    }
  }
}
