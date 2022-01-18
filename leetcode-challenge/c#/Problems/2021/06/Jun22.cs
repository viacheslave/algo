using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/606/week-4-june-22nd-june-28th/3788/
  /// 
  /// </summary>
  internal class Jun22
  {
    public class Solution
    {
      public int NumMatchingSubseq(string S, string[] words)
      {
        var map = new Dictionary<string, bool>();
        var ans = 0;

        foreach (var word in words)
        {
          var sub = map.ContainsKey(word) ? map[word] : IsSubsequence(word, S);
          if (sub)
            ans++;

          map[word] = sub;
        }

        return ans;
      }

      public bool IsSubsequence(string s, string t)
      {
        var fi = 0;

        for (var i = 0; i < t.Length; i++)
        {
          if (s[fi] == t[i])
          {
            fi++;
            if (fi == s.Length)
              return true;
          }
        }

        return false;
      }
    }
  }
}
