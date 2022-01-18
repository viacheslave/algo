using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/585/week-2-february-8th-february-14th/3638/
  ///    
  /// </summary>
  internal class Feb13
  {
    public class Solution
    {
      public int ShortestPathBinaryMatrix(int[][] grid)
      {
        var hs = new HashSet<(int, int)>();
        var q = new Queue<(int, int, int)>();
        var min = int.MaxValue;

        q.Enqueue((0, 0, 1));

        while (q.Count > 0)
        {
          var el = q.Dequeue();

          if (el.Item1 < 0 || el.Item2 < 0 || el.Item1 >= grid.Length || el.Item2 >= grid.Length)
            continue;

          if (grid[el.Item1][el.Item2] == 1)
            continue;

          if (hs.Contains((el.Item1, el.Item2)))
            continue;

          hs.Add((el.Item1, el.Item2));

          if (el.Item1 == grid.Length - 1 && el.Item2 == grid.Length - 1)
          {
            if (el.Item3 < min) min = el.Item3;
            continue;
          }

          q.Enqueue((el.Item1 + 1, el.Item2 - 1, el.Item3 + 1));
          q.Enqueue((el.Item1 + 1, el.Item2 + 0, el.Item3 + 1));
          q.Enqueue((el.Item1 + 1, el.Item2 + 1, el.Item3 + 1));
          q.Enqueue((el.Item1 + 0, el.Item2 - 1, el.Item3 + 1));
          q.Enqueue((el.Item1 + 0, el.Item2 + 1, el.Item3 + 1));
          q.Enqueue((el.Item1 - 1, el.Item2 + 0, el.Item3 + 1));
          q.Enqueue((el.Item1 - 1, el.Item2 + 1, el.Item3 + 1));
        }

        return min == int.MaxValue ? -1 : min;
      }
    }
  }
}
