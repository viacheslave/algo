using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/615/week-3-august-15th-august-21st/3902/
  /// 
  /// </summary>
  internal class Aug18
  {
    public class Solution
    {
      public int NumDecodings(string s)
      {
        if (string.IsNullOrEmpty(s))
          return 0;

        if (s.Length == 1)
          return s[0] == '0' ? 0 : 1;

        var map = new Dictionary<int, int>()
        {
          [0] = 1,
          [1] = s[s.Length - 1] == '0' ? 0 : 1
        };

        for (var index = s.Length - 2; index >= 0; index--)
        {
          var num = s.Length - index;

          var min1 = map[num - 1];
          var min2 = map[num - 2];

          var count = 0;
          if (s[index] != '0')
            count += min1;

          var two = int.Parse(s.Substring(index, 2));
          if (10 <= two && two <= 26)
            count += min2;

          map[num] = count;
        }

        return map[s.Length];
      }
    }
  }
}
