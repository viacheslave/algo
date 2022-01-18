using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/598/week-1-may-1st-may-7th/3734/
  /// 
  /// </summary>
  internal class May07
  {
    public class Solution
    {
      public int MinDistance(string word1, string word2)
      {
        var map = new Dictionary<(int, int), int>();
        var longestcommon = Longest(word1, word1.Length, word2, word2.Length, map);

        return word1.Length - longestcommon + word2.Length - longestcommon;
      }

      private int Longest(string text1, int n1, string text2, int n2, Dictionary<(int, int), int> map)
      {
        if (n1 == 0 || n2 == 0)
          return 0;

        if (map.ContainsKey((n1, n2)))
          return map[(n1, n2)];

        var res = 0;

        if (text1[n1 - 1] == text2[n2 - 1])
          res = Longest(text1, n1 - 1, text2, n2 - 1, map) + 1;
        else
          res = Math.Max(Longest(text1, n1 - 1, text2, n2, map), Longest(text1, n1, text2, n2 - 1, map));

        map[(n1, n2)] = res;
        return res;
      }
    }
  }
}
