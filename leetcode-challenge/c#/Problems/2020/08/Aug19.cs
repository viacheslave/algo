using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/551/week-3-august-15th-august-21st/3429/
  ///    https://leetcode.com/submissions/detail/383222946/?from=/explore/challenge/card/august-leetcoding-challenge/551/week-3-august-15th-august-21st/3429/
  /// </summary>
  internal class Aug19
  {
    public class Solution
    {
      public string ToGoatLatin(string S)
      {
        var words = S.Split(new char[] { ' ' });

        for (var i = 0; i < words.Length; i++)
        {
          var f = Char.ToLower(words[i][0]);

          if (
             f == 'a' ||
             f == 'e' ||
             f == 'i' ||
             f == 'o' ||
             f == 'u')
            words[i] = words[i] + "ma";
          else
          {
            words[i] = (words[i].Length == 1)
                ? words[i] + "ma"
                : words[i].Substring(1) + words[i][0] + "ma";
          }

          words[i] = words[i] + new string('a', i + 1);
        }

        return string.Join(' ', words);
      }
    }
  }
}
