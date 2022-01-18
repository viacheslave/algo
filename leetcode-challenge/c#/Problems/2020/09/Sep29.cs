using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.September.Challenge.Problems
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/558/week-5-september-29th-september-30th/3477/
  ///    https://leetcode.com/submissions/detail/402158548/?from=/explore/challenge/card/september-leetcoding-challenge/558/week-5-september-29th-september-30th/3477/
  /// </summary>
  internal class Sep29
  {
    public class Solution
    {
      public bool WordBreak(string s, IList<string> wordDict)
      {
        var dp = new Dictionary<string, bool>();

        dp[""] = true;

        var can = CanBreak(dp, s, wordDict);
        return can;
      }

      public bool CanBreak(Dictionary<string, bool> dp, string s, IList<string> wordDict)
      {
        if (dp.ContainsKey(s))
          return dp[s];

        var res = false;

        foreach (var word in wordDict)
        {
          if (s == word)
          {
            dp[s] = true;
            return dp[s];
          }

          var index = s.IndexOf(word);
          if (index == -1)
            continue;

          var local = true;

          var words = new[] { s.Substring(0, index), s.Substring(index + word.Length) };
          foreach (var w in words)
            local = local && CanBreak(dp, w, wordDict);

          res = res || local;
        }

        dp[s] = res;
        return dp[s];
      }
    }
  }
}
