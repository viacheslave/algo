using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3607/
  ///    https://leetcode.com/submissions/detail/444082433/?from=explore&item_id=3607
  /// </summary>
  internal class Jan17
  {
    public class Solution
    {
      public int CountVowelStrings(int n)
      {
        var dp = new int[n + 1, 255];
        var ch = new SortedSet<int>(new int[] { 'a', 'e', 'i', 'o', 'u' });

        foreach (var t in ch)
          dp[1, t] = 1;

        for (var i = 2; i <= n; i++)
          foreach (var c in ch)
            dp[i, c] = ch.GetViewBetween('a', c).Select(x => dp[i - 1, x]).Sum();

        return ch.Select(x => dp[n, x]).Sum();
      }
    }
  }
}

