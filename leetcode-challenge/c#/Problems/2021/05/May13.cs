using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/599/week-2-may-8th-may-14th/3741/
  /// 
  /// </summary>
  internal class May13
  {
    public class Solution
    {
      public IList<string> AmbiguousCoordinates(string S)
      {
        var res = new List<string>();

        var stripped = S.Trim(new[] { '(', ')' });

        for (var i = 0; i < stripped.Length - 1; i++)
        {
          Process(res, stripped, i);
        }

        return res;
      }

      private void Process(List<string> res, string s, int comma)
      {
        var p1 = s.Substring(0, comma + 1);
        var p2 = s.Substring(comma + 1);

        var vars1 = GetVars(p1);
        var vars2 = GetVars(p2);

        foreach (var v1 in vars1)
          foreach (var v2 in vars2)
            res.Add("(" + v1 + ", " + v2 + ")");
      }

      private List<string> GetVars(string s)
      {
        var vars = new List<string>();

        if (s == "0" || s.TrimStart(new[] { '0' }) == s)
          vars.Add(s);

        for (var i = 0; i < s.Length - 1; i++)
        {
          var p1 = s.Substring(0, i + 1);
          var p2 = s.Substring(i + 1);

          if (p1 != "0" && p1.TrimStart(new[] { '0' }) != p1)
            continue;

          if (p2.TrimEnd(new[] { '0' }) != p2)
            continue;

          vars.Add(p1 + "." + p2);
        }

        return vars;
      }
    }
  }
}
