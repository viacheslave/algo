using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3665/
  /// 
  /// </summary>
  internal class Mar08
  {
    public class Solution
    {
      public int RemovePalindromeSub(string s)
      {
        if (string.IsNullOrEmpty(s))
          return 0;

        if (s.Length == 1) return 1;
        if (IsPalindromic(s)) return 1;
        return 2;
      }

      private bool IsPalindromic(string s)
      {
        for (var i = 0; i < s.Length / 2; i++)
          if (s[i] != s[s.Length - 1 - i])
            return false;
        return true;
      }
    }
  }
}
