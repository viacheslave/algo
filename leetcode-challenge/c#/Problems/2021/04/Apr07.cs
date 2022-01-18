using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3699/
  /// 
  /// </summary>
  internal class Apr07
  {
    public class Solution
    {
      public bool HalvesAreAlike(string s)
      {
        var set = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        var indexes = new List<int>();

        for (var i = 0; i < s.Length; i++)
          if (set.Contains(s[i]))
            indexes.Add(i);

        return indexes.Count(i => i < s.Length / 2) == indexes.Count(i => i >= s.Length / 2);
      }
    }
  }
}
