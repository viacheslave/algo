using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3454/
  ///    https://leetcode.com/submissions/detail/393213183/?from=/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3454/
  /// </summary>
  internal class Sep09
  {
    public class Solution
    {
      public int CompareVersion(string version1, string version2)
      {
        var ch1 = version1.Split('.');
        var ch2 = version2.Split('.');

        int res = 0;

        for (var i = 0; i < Math.Max(ch1.Length, ch2.Length); i++)
        {
          var c1 = i >= ch1.Length ? 0 : int.Parse(ch1[i].ToString());
          var c2 = i >= ch2.Length ? 0 : int.Parse(ch2[i].ToString());

          var comp = c1.CompareTo(c2);

          if (comp != 0)
            return comp;
        }

        return 0;
      }
    }
  }
}
