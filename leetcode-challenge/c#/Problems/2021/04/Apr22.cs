using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3717/
  /// 
  /// </summary>
  internal class Apr22
  {
    public class Solution
    {
      public int LeastBricks(IList<IList<int>> wall)
      {
        var rowLength = wall[0].Sum();
        var map = new Dictionary<int, int>();

        foreach (var row in wall)
        {
          var l = 0;
          foreach (var brick in row)
          {
            l += brick;
            if (!map.ContainsKey(l)) map[l] = 0;
            map[l]++;
          }
        }

        var candidate = map.OrderByDescending(_ => _.Value)
            .Where(_ => _.Key != rowLength)
            .FirstOrDefault();

        if (candidate.Key == 0)
          return wall.Count;

        return wall.Count - candidate.Value;
      }
    }
  }
}
