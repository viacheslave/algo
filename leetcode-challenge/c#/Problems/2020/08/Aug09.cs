using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{

  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3418/
  ///    https://leetcode.com/submissions/detail/378298610/?from=/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3418/
  /// </summary>
  internal class Aug09
  {
    public class Solution
    {
      public int OrangesRotting(int[][] grid)
      {
        var ans = 0;

        var freshSet = new HashSet<(int row, int col)>();
        for (int i = 0; i < grid.Length; i++)
          for (int j = 0; j < grid[0].Length; j++)
            if (grid[i][j] == 1)
              freshSet.Add((i, j));

        while (true)
        {
          var delete = new HashSet<(int row, int col)>();
          foreach (var (row, col) in freshSet)
          {
            if (ConnectsToRotten(grid, row, col))
              delete.Add((row, col));
          }

          if (delete.Count > 0)
          {
            foreach (var deleteItem in delete)
            {
              freshSet.Remove(deleteItem);
              grid[deleteItem.row][deleteItem.col] = 2;
            }

            ans++;
            continue;
          }

          if (freshSet.Count == 0)
            return ans;

          return -1;
        }
      }

      private bool ConnectsToRotten(int[][] grid, int row, int col)
      {
        var neighbors = new List<(int row, int col)>();

        neighbors.Add((row + 1, col));
        neighbors.Add((row - 1, col));
        neighbors.Add((row, col + 1));
        neighbors.Add((row, col - 1));

        foreach (var item in neighbors)
        {
          if (item.row >= 0 && item.row < grid.Length &&
                item.col >= 0 && item.col < grid[0].Length)
          {
            if (grid[item.row][item.col] == 2)
              return true;
          }
        }

        return false;
      }
    }
  }
}
