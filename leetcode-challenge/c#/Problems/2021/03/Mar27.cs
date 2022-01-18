using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3686/
  ///   
  /// </summary>
  internal class Mar27
  {
    public class Solution
    {
      public int CountSubstrings(string s)
      {
        if (string.IsNullOrEmpty(s))
          return 0;

        if (s.Length == 1)
          return 1;

        var sub = 0;

        for (var i = 0; i < s.Length; i++)
        {
          sub++;

          var left = i;
          var right = i + 1;

          while (left >= 0 && right < s.Length && s[left] == s[right])
          {
            sub++;

            left--;
            right++;
          }

          left = i;
          right = i + 2;

          while (left >= 0 && right < s.Length && s[left] == s[right])
          {
            sub++;

            left--;
            right++;
          }
        }

        return sub;
      }
    }
  }
}
