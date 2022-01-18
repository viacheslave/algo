using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/585/week-2-february-8th-february-14th/3636/
  ///    
  /// </summary>
  internal class Feb11
  {
    public class Solution
    {
      public bool IsAnagram(string s, string t)
      {
        var s1 = GetSum(s);
        var s2 = GetSum(t);

        if (s1.Count() != s2.Count())
          return false;

        foreach (var k in s1)
        {
          if (!s2.ContainsKey(k.Key))
            return false;

          var l = s2[k.Key];
          if (k.Value != l)
            return false;
        }

        return true;
      }

      private Dictionary<char, int> GetSum(string s)
      {
        var d = new Dictionary<char, int>();
        foreach (var ch in s)
        {
          if (!d.ContainsKey(ch))
            d.Add(ch, 0);

          d[ch]++;
        }

        return d;
      }
    }
  }
}
