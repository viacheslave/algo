using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.September.Challenge.Problems
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/557/week-4-september-22nd-september-28th/3471/
  /// </summary>
  internal class Sep24
  {
    public class Solution
    {
      public char FindTheDifference(string s, string t)
      {
        Dictionary<char, int> sMap = new Dictionary<char, int>();
        Dictionary<char, int> tMap = new Dictionary<char, int>();

        foreach (var ch in s)
        {
          if (!sMap.ContainsKey(ch))
            sMap[ch] = 0;

          sMap[ch]++;
        }

        foreach (var ch in t)
        {
          if (!tMap.ContainsKey(ch))
            tMap[ch] = 0;

          tMap[ch]++;
        }

        foreach (var kvp in tMap)
        {
          if (!sMap.ContainsKey(kvp.Key) || sMap[kvp.Key] != kvp.Value)
            return kvp.Key;


        }

        return ' ';
      }
    }
  }
}
