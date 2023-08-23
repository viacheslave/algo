namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-fish-in-a-grid/
///    Submission: https://leetcode.com/problems/maximum-number-of-fish-in-a-grid/submissions/942556424/
/// </summary>
internal class P2658
{
  public class Solution
  {
    public int FindMaxFish(int[][] grid)
    {
      var visited = new HashSet<(int x, int y)>();

      var ans = 0;

      for (int i = 0; i < grid.Length; i++)
      {
        for (int j = 0; j < grid[i].Length; j++)
        {
          if (visited.Contains((i, j)))
            continue;

          if (grid[i][j] == 0)
            continue;

          var count = Collect(grid, i, j, visited);
          ans = Math.Max(ans, count);
        }
      }

      return ans;
    }

    private int Collect(int[][] grid, int i, int j, HashSet<(int x, int y)> visited)
    {
      // BFS
      var queue = new Queue<(int x, int y)>();
      queue.Enqueue((i, j));

      var count = 0;

      var paths = new List<(int, int)>
    {
      (0, 1),
      (1, 0),
      (0, -1),
      (-1, 0),
    };

      while (queue.Count > 0)
      {
        var item = queue.Dequeue();
        if (visited.Contains(item))
          continue;

        visited.Add(item);
        count += grid[item.x][item.y];

        foreach (var path in paths)
        {
          var cell = (x: item.x + path.Item1, y: item.y + path.Item2);
          if (cell.x >= 0 && cell.y >= 0 && cell.x < grid.Length && cell.y < grid[0].Length)
          {
            if (grid[cell.x][cell.y] > 0)
            {
              queue.Enqueue(cell);
            }
          }
        }
      }

      return count;
    }
  }
}
