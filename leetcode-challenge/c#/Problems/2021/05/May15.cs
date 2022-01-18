using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/600/week-3-may-15th-may-21st/3744/
  /// 
  /// </summary>
  internal class May15
  {
    public class Solution
    {
      public bool IsNumber(string s)
      {
        s = s.Trim();

        if (s?.Length == 0)
          return false;

        var parts = s.Split('e');
        if (parts.Length > 2)
          return false;

        if (parts.Length == 2)
          return IsNum(parts[0]) && IsExponent(parts[1]);

        return IsNum(parts[0]);
      }

      private bool IsExponent(string s)
      {
        if (s.Length == 0)
          return false;

        if (s.StartsWith("+") || s.StartsWith("-"))
          s = s.Substring(1);

        if (s.Length == 0)
          return false;

        return s.All(Char.IsDigit);
      }

      private bool IsNum(string s)
      {
        if (s.Length == 0)
          return false;

        if (s.Trim() != s)
          return false;

        var res = double.TryParse(s, out var d);
        if (double.IsInfinity(d))
          return false;

        return res;
      }
    }
  }
}
