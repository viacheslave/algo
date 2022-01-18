using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/560/week-2-october-8th-october-14th/3490/
  ///    https://leetcode.com/submissions/detail/406931175/?from=/explore/challenge/card/october-leetcoding-challenge/560/week-2-october-8th-october-14th/3490/
  /// </summary>
  internal class Oct10
  {
    public class Solution
    {
      public int FindMinArrowShots(int[][] points)
      {
        if (points.Length == 0)
          return 0;

        var ps = points.OrderBy(x => x[1])
            .Select(x => (start: x[0], end: x[1]))
            .ToList();

        var ans = 1;

        var pointer = ps[0].end;

        for (var i = 0; i < ps.Count; i++)
        {
          var point = ps[i];
          if (point.start <= pointer)
            continue;

          ans++;
          pointer = point.end;
        }

        return ans;
      }
    }
  }
}
