using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/609/week-2-july-8th-july-14th/3813/
  /// 
  /// </summary>
  internal class Jul14
  {
    public class Solution
    {
      public string CustomSortString(string S, string T)
      {
        var tmap = T.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count());

        var sb = new StringBuilder();

        foreach (var s in S)
        {
          if (tmap.ContainsKey(s))
          {
            sb.Append(new string(Enumerable.Repeat(s, tmap[s]).ToArray()));
            tmap[s] = 0;
          }
        }

        foreach (var t in tmap.Where(_ => _.Value != 0))
        {
          sb.Append(new string(Enumerable.Repeat(t.Key, t.Value).ToArray()));
        }

        return sb.ToString();
      }
    }
  }
}
