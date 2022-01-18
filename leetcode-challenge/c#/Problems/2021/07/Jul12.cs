using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/609/week-2-july-8th-july-14th/3811/
  /// 
  /// </summary>
  internal class Jul12
  {
    public class Solution
    {
      public bool IsIsomorphic(string s, string t)
      {
        var map = new Dictionary<char, char>();
        var taken = new HashSet<char>();

        for (var i = 0; i < s.Length; i++)
        {
          if (!map.ContainsKey(s[i]))
          {
            if (taken.Contains(t[i]))
              return false;

            map.Add(s[i], t[i]);
            taken.Add(t[i]);
            continue;
          }

          if (map[s[i]] != t[i])
            return false;
        }

        return true;
      }
    }
  }
}
