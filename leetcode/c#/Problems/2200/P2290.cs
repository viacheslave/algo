namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-obstacle-removal-to-reach-corner/
///    Submission: https://leetcode.com/submissions/detail/712020601/
/// </summary>
internal class P2290
{
  public class Solution
  {
    public int MinimumObstacles(int[][] grid)
    {
      // build adj list
      var edges = new Dictionary<(int x, int y), List<(int x, int y, int cost)>>();

      var m = grid.Length;
      var n = grid[0].Length;

      for (int i = 0; i < m; i++)
      {
        for (int j = 0; j < n; j++)
        {
          var adj = new List<(int x, int y)>
        {
          (i - 1, j),
          (i + 1, j),
          (i, j - 1),
          (i, j + 1),
        };

          var list = new List<(int x, int y, int cost)>();

          foreach (var (x, y) in adj)
          {
            if (x >= 0 && y >= 0 && x < m && y < n)
            {
              list.Add((x, y, grid[x][y]));
            }
          }

          edges[(i, j)] = list;
        }
      }

      // dijkstra shortest path
      var visited = new HashSet<(int, int)>();
      var distances = new Dictionary<(int, int), int>();

      for (int i = 0; i < m; i++)
      {
        for (int j = 0; j < n; j++)
        {
          distances[(i, j)] = int.MaxValue;
        }
      }

      distances[(0, 0)] = 0;

      var pq = new PriorityQueue<((int x, int y) loc, int d), int>();
      pq.Enqueue(((0, 0), 0), distances[(0, 0)]);

      while (pq.Count > 0)
      {
        var el = pq.Dequeue();

        visited.Add(el.loc);

        if (distances[el.loc] < el.d)
          continue;

        foreach (var adj in edges[el.loc])
        {
          if (visited.Contains((adj.x, adj.y)))
            continue;

          var proposed = distances[el.loc] + adj.cost;
          if (proposed < distances[(adj.x, adj.y)])
          {
            distances[(adj.x, adj.y)] = proposed;
            pq.Enqueue(((adj.x, adj.y), proposed), proposed);
          }
        }

        if (el.loc == (m - 1, n - 1))
          break;
      }

      return distances[(m - 1, n - 1)];
    }
  }
}
