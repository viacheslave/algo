using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3455/
  ///    https://leetcode.com/submissions/detail/393719362/?from=/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3455/
  /// </summary>
  internal class Sep10
  {
    public class Solution
    {
      public string GetHint(string secret, string guess)
      {
        var bulls = 0;
        var cows = 0;

        var hg = new HashSet<int>();
        var processed = new HashSet<int>();

        for (var i = 0; i < guess.Length; i++)
        {
          if (secret[i] == guess[i])
          {
            bulls++;
            processed.Add(i);
            hg.Add(i);
          }
        }

        for (var i = 0; i < guess.Length; i++)
        {
          if (!hg.Contains(i) && Contains(secret, guess[i], processed))
          {
            cows++;
          }
        }

        return $"{bulls}A{cows}B";
      }

      bool Contains(string secret, char g, HashSet<int> hs)
      {
        for (var i = 0; i < secret.Length; i++)
        {
          if (!hs.Contains(i) && secret[i] == g)
          {
            hs.Add(i);
            return true;
          }
        }

        return false;
      }
    }
  }
}
