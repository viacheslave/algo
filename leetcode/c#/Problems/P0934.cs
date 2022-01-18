namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/shortest-bridge/
///    Submission: https://leetcode.com/problems/shortest-bridge/
/// </summary>
internal class P0934
{
  public class Solution
  {
    public int ShortestBridge(int[][] grid)
    {
      var firstLand = (-1, -1);
      var rows = grid.Length;
      var cols = grid[0].Length;

      // find first land
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < cols; j++)
        {
          if (grid[i][j] == 1)
          {
            firstLand = (i, j);
            break;
          }
        }
      }

      // DFS one of the islands
      var island = new HashSet<(int, int)>();

      var queue = new Queue<(int, int)>();
      queue.Enqueue(firstLand);

      while (queue.Count > 0)
      {
        var item = queue.Dequeue();
        if (island.Contains(item))
          continue;

        island.Add(item);

        var neighbors = new List<(int, int)>
      {
        (item.Item1 + 1, item.Item2),
        (item.Item1 - 1, item.Item2),
        (item.Item1, item.Item2 + 1),
        (item.Item1, item.Item2 - 1),
      };

        foreach (var n in neighbors)
        {
          if (island.Contains(n))
            continue;

          if (n.Item1 < 0 || n.Item1 >= rows || n.Item2 < 0 || n.Item2 >= cols)
            continue;

          if (grid[n.Item1][n.Item2] == 0)
            continue;

          queue.Enqueue(n);
        }
      }

      // get island border squares
      var borderland = new HashSet<(int, int)>();

      foreach (var item in island)
      {
        var neighbors = new List<(int, int)>
      {
        (item.Item1 + 1, item.Item2),
        (item.Item1 - 1, item.Item2),
        (item.Item1, item.Item2 + 1),
        (item.Item1, item.Item2 - 1),
      };

        foreach (var n in neighbors)
        {
          if (n.Item1 < 0 || n.Item1 >= rows || n.Item2 < 0 || n.Item2 >= cols)
            continue;

          if (grid[n.Item1][n.Item2] == 0)
            borderland.Add(item);
        }
      }

      // DFS from border squares
      var ans = int.MaxValue;

      // sort borderland
      var items = borderland.ToList().OrderByDescending(x => x, new Comparer(rows, cols))
        .ToList();

      foreach (var bordersq in items)
      {
        var visited = new HashSet<(int, int)>();

        var q = new Queue<(int, int, int)>();
        q.Enqueue((bordersq.Item1, bordersq.Item2, 0));

        while (q.Count > 0)
        {
          var item = q.Dequeue();
          if (visited.Contains((item.Item1, item.Item2)))
            continue;

          visited.Add((item.Item1, item.Item2));

          var neighbors = new List<(int, int)>
        {
          (item.Item1 + 1, item.Item2),
          (item.Item1 - 1, item.Item2),
          (item.Item1, item.Item2 + 1),
          (item.Item1, item.Item2 - 1),
        };

          foreach (var n in neighbors)
          {
            if (island.Contains(n))
              continue;

            if (visited.Contains(n))
              continue;

            if (n.Item1 < 0 || n.Item1 >= rows || n.Item2 < 0 || n.Item2 >= cols)
              continue;

            if (grid[n.Item1][n.Item2] == 0)
            {
              if (!visited.Contains(n) && item.Item3 + 1 < ans)
                q.Enqueue((n.Item1, n.Item2, item.Item3 + 1));
            }
            else
            {
              ans = Math.Min(ans, item.Item3);

              // return minimum possible
              if (ans == 1)
                return 1;
            }
          }
        }
      }

      return ans;
    }

    public class Comparer : IComparer<(int, int)>
    {
      private readonly int _rows;
      private readonly int _cols;

      public Comparer(int rows, int cols)
      {
        _rows = rows;
        _cols = cols;
      }

      public int Compare((int, int) x, (int, int) y)
      {
        var mx = Math.Min(
          Math.Min(x.Item1, _rows - x.Item1),
          Math.Min(x.Item2, _cols - x.Item2)
        );

        var my = Math.Min(
          Math.Min(y.Item1, _rows - y.Item1),
          Math.Min(y.Item2, _cols - y.Item2)
        );

        return mx.CompareTo(my);
      }
    }
  }
}
