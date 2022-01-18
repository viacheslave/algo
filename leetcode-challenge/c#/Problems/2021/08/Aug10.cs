using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/614/week-2-august-8th-august-14th/3876/
  /// 
  /// </summary>
  internal class Aug12
  {
    public class Solution
    {
      public IList<IList<string>> GroupAnagrams(string[] strs)
      {
        var d = new Dictionary<string, IList<string>>();


        foreach (var str in strs)
        {
          var arr = str.ToCharArray();
          Array.Sort(arr);
          var s = new string(arr);

          if (!d.ContainsKey(s))
            d[s] = new List<string>();

          d[s].Add(str);
        }

        return d.Values.ToList();
      }
    }
  }
}
