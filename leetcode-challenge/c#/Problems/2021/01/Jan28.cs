using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3619/
  ///    https://leetcode.com/submissions/detail/448954592/?from=explore&item_id=3619
  /// </summary>
  internal class Jan28
  {
    public class Solution
    {
      public string GetSmallestString(int n, int k)
      {
        var ans = new List<int>();

        while (n > 0)
        {
          var max = Math.Min(k - (n - 1), 26);
          ans.Add(max);

          k -= max;
          n--;
        }

        ans.Reverse();

        return new string(ans.Select(i => (char)(97 - 1 + i)).ToArray());
      }
    }
  }
}

