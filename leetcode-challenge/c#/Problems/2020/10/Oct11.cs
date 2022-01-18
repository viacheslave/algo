using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/560/week-2-october-8th-october-14th/3491/
  ///    https://leetcode.com/submissions/detail/407333726/?from=/explore/challenge/card/october-leetcoding-challenge/560/week-2-october-8th-october-14th/3491/
  /// </summary>
  internal class Oct11
  {
    public class Solution
    {
      public string RemoveDuplicateLetters(string s)
      {
        var chMap = s.GroupBy(c => c)
            .ToDictionary(c => c.Key, c => c.Count());

        var processed = s.Distinct()
            .ToDictionary(c => c, _ => false);

        var sb = new StringBuilder();

        for (var i = 0; i < s.Length; i++)
        {
          var ch = s[i];

          chMap[ch]--;

          if (processed[ch])
            continue;

          while (sb.Length > 0)
          {
            var last = sb[^1];

            if (last > ch && chMap[last] > 0)
            {
              processed[last] = false;
              sb.Remove(sb.Length - 1, 1);

              continue;
            }

            break;
          }

          processed[ch] = true;
          sb.Append(ch);
        }

        return sb.ToString();
      }
    }
  }
}
