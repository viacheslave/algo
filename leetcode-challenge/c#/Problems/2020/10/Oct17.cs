using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3498/
  ///    https://leetcode.com/submissions/detail/409729029/?from=/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3498/
  /// </summary>
  internal class Oct17
  {
    public class Solution
    {
      public IList<string> FindRepeatedDnaSequences(string s)
      {
        var map = new Dictionary<string, int>();

        for (var i = 0; i < s.Length - 10 + 1; i++)
        {
          var sub = s.Substring(i, 10);
          if (!map.ContainsKey(sub)) map[sub] = 0;
          map[sub]++;
        }

        return map.Where(_ => _.Value > 1).Select(_ => _.Key).ToList();
      }
    }
  }
}
