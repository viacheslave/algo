using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3649/
  ///   https://leetcode.com/submissions/detail/459175674/?from=explore&item_id=3649
  /// </summary>
  internal class Feb22
  {
    public class Solution
    {
      public string FindLongestWord(string s, IList<string> d)
      {
        if (s.Length == 0)
          return string.Empty;

        var longest = string.Empty;

        foreach (var word in d)
        {
          var res = GetLongest(s, word);
          if (res.Length > longest.Length)
          {
            longest = res;
            continue;
          }

          if (res.Length == longest.Length && res == new string[] { res, longest }.OrderBy(_ => _).First())
            longest = res;
        }

        return longest;
      }

      private string GetLongest(string str, string word)
      {
        int s = 0;

        for (var w = 0; w < word.Length; w++)
        {
          if (s >= str.Length)
            return string.Empty;

          if (word[w] == str[s])
          {
            s++;
            continue;
          }

          var found = false;
          while (s < str.Length)
          {
            if (word[w] == str[s])
            {
              found = true;
              s++;
              break;
            }

            s++;
          }

          if (found)
            continue;

          return string.Empty;
        }

        return word;
      }
    }
  }
}
