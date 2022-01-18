using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/600/week-3-may-15th-may-21st/3750/
  /// 
  /// </summary>
  internal class May21
  {
    public class Solution
    {
      public IList<string> FindAndReplacePattern(string[] words, string pattern)
      {
        var res = new List<string>();

        foreach (var word in words)
        {
          var one = new Dictionary<char, char>();
          var two = new Dictionary<char, char>();

          var matches = true;

          for (var i = 0; i < pattern.Length; i++)
          {
            if (one.ContainsKey(word[i]) && one[word[i]] != pattern[i])
            {
              matches = false;
              break;
            }

            if (two.ContainsKey(pattern[i]) && two[pattern[i]] != word[i])
            {
              matches = false;
              break;
            }

            one[word[i]] = pattern[i];
            two[pattern[i]] = word[i];
          }

          if (one.Count != two.Count)
            continue;

          foreach (var item in one)
          {
            if (!two.ContainsKey(item.Value) || two[item.Value] != item.Key)
            {
              matches = false;
              break;
            }
          }

          if (matches)
            res.Add(word);
        }

        return res;
      }
    }
  }
}
