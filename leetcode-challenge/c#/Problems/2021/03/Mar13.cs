using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3670/
  ///   
  /// </summary>
  internal class Mar13
  {
    public class Solution
    {
      public int NumFactoredBinaryTrees(int[] A)
      {
        Array.Sort(A);
        var map = A.Select((a, i) => (a, i)).ToDictionary(_ => _.a, _ => _.i);
        var dp = Enumerable.Repeat(1L, A.Length).ToArray();

        for (var i = 0; i < A.Length; i++)
        {
          for (var j = 0; j < i; j++)
          {
            var root = A[i];
            var left = A[j];

            if (root % left == 0 && map.ContainsKey(root / left))
            {
              var right = root / left;
              var il = dp[map[left]];
              var ir = dp[map[right]];

              dp[map[root]] += il * ir;
            }
          }
        }

        var ans = 0L;
        for (var i = 0; i < A.Length; i++)
          ans += dp[i];

        var mod = 1_000_000_007;
        return (int)(ans % mod);
      }
    }
  }
}
