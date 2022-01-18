using System.Collections.Generic;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3595/
  ///    https://leetcode.com/submissions/detail/439725193/?from=explore&item_id=3595
  /// </summary>
  internal class Jan07
  {
    public class Solution
    {
      public int LengthOfLongestSubstring(string s)
      {
        if (string.IsNullOrEmpty(s))
          return 0;

        var hs = new Dictionary<char, int>();

        var max = 0;
        var firstCh = 0;

        for (var i = 0; i < s.Length; i++)
        {
          if (hs.ContainsKey(s[i]))
          {
            var newfirst = hs[s[i]] + 1;

            for (var j = firstCh; j <= hs[s[i]] - 1; j++)
            {
              hs.Remove(s[j]);
            }

            firstCh = newfirst;
            hs[s[i]] = i;
            continue;
          }

          hs[s[i]] = i;

          if (max < (i - firstCh + 1))
            max = i - firstCh + 1;
        }

        return max;
      }
    }
  }
}

