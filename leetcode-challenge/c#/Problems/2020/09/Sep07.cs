using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/554/week-1-september-1st-september-7th/3451/
  ///    https://leetcode.com/submissions/detail/392212995/?from=/explore/challenge/card/september-leetcoding-challenge/554/week-1-september-1st-september-7th/3451/  
  /// </summary>
  internal class Sep07
  {
    public class Solution
    {
      public bool WordPattern(string pattern, string str)
      {
        var words = str.Split(' ');

        if (words.Length != pattern.Length)
          return false;

        var map = new Dictionary<char, string>();
        var taken = new HashSet<string>();

        for (var i = 0; i < pattern.Length; i++)
        {
          if (map.ContainsKey(pattern[i]))
          {
            if (map[pattern[i]] != words[i])
              return false;
          }
          else
          {
            if (taken.Contains(words[i]))
              return false;

            map[pattern[i]] = words[i];
            taken.Add(words[i]);
          }
        }

        return true;
      }
    }
  }
}
