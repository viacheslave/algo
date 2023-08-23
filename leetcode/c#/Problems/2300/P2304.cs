namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-path-cost-in-a-grid/
///    Submission: https://leetcode.com/submissions/detail/721149404/
/// </summary>
internal class P2304
{
  public class Solution
  {
    public int MinPathCost(int[][] grid, int[][] moveCost)
    {
      var rows = grid.Length;
      var cols = grid[0].Length;

      var cost = new int[rows * cols];

      // initial
      for (var i = 0; i < rows; i++)
      {
        for (var j = 0; j < cols; j++)
        {
          var id = grid[i][j];

          if (i == 0)
          {
            cost[id] = id;
          }
          else
          {
            cost[id] = int.MaxValue;
          }
        }
      }

      for (var i = 0; i < rows - 1; i++)
      {
        var r = i + 1;

        for (var j = 0; j < cols; j++)
        {
          var id = grid[i][j];
          var costs = moveCost[id];

          for (var k = 0; k < cols; k++)
          {
            var nextId = grid[r][k];

            cost[nextId] = Math.Min(
              cost[nextId],
              cost[id] + costs[k] + nextId
            );
          }
        }
      }

      var ans = int.MaxValue;

      for (var j = 0; j < cols; j++)
      {
        ans = Math.Min(ans, cost[grid[rows - 1][j]]);
      }

      return ans;
    }
  }
}
