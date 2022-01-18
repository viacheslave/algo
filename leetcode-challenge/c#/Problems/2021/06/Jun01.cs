using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/603/week-1-june-1st-june-7th/3764/
  /// 
  /// </summary>
  internal class Jun01
  {
    public class Solution
    {
      public int MaxAreaOfIsland(int[][] grid)
      {
        var visited = new HashSet<(int, int)>();
        var maxArea = 0;

        for (int i = 0; i < grid.Length; i++)
        {
          for (int j = 0; j < grid[i].Length; j++)
          {
            if (grid[i][j] == 1 && !visited.Contains((i, j)))
            {
              maxArea = Math.Max(maxArea, GetArea(grid, visited, (i, j)));
            }
          }
        }

        return maxArea;
      }

      private int GetArea(int[][] grid, HashSet<(int, int)> visited, (int i, int j) p)
      {
        var queue = new Queue<(int, int)>();
        var area = 0;

        queue.Enqueue((p.i, p.j));

        while (queue.Count > 0)
        {
          var cell = queue.Dequeue();
          if (visited.Contains((cell.Item1, cell.Item2)))
            continue;

          area++;
          visited.Add(cell);

          var next = (cell.Item1 + 1, cell.Item2);
          if (InBound(next, grid) && grid[next.Item1][next.Item2] == 1)
            queue.Enqueue(next);

          next = (cell.Item1 - 1, cell.Item2);
          if (InBound(next, grid) && grid[next.Item1][next.Item2] == 1)
            queue.Enqueue(next);

          next = (cell.Item1, cell.Item2 + 1);
          if (InBound(next, grid) && grid[next.Item1][next.Item2] == 1)
            queue.Enqueue(next);

          next = (cell.Item1, cell.Item2 - 1);
          if (InBound(next, grid) && grid[next.Item1][next.Item2] == 1)
            queue.Enqueue(next);
        }

        return area;
      }

      private bool InBound((int, int) next, int[][] grid)
      {
        return
            next.Item1 >= 0 &&
            next.Item2 >= 0 &&
            next.Item1 < grid.Length &&
            next.Item2 < grid[0].Length;
      }
    }
  }
}
