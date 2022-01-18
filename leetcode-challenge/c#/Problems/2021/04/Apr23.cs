using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3718/
  /// 
  /// </summary>
  internal class Apr23
  {
    public class Solution
    {
      public int CountBinarySubstrings(string s)
      {
        if (s.Length < 2)
          return 0;

        var res = 0;

        for (var i = 1; i < s.Length; i++)
        {
          if (s[i] != s[i - 1])
            res += Get(s, i - 1, i);
        }


        return res;
      }

      int Get(string s, int i, int j)
      {
        var res = 1;

        while (true)
        {
          i--; j++;

          if (i < 0 || j >= s.Length)
            return res;

          if (s[i] == s[i + 1] && s[j] == s[j - 1])
            res++;

          else break;
        }

        return res;
      }
    }
  }
}
