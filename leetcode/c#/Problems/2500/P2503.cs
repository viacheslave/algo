namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-points-from-grid-queries/
///    Submission: https://leetcode.com/problems/maximum-number-of-points-from-grid-queries/submissions/862736585/
/// </summary>
internal class P2503
{
  public class Solution
  {
    public int[] MaxPoints(int[][] grid, int[] queries)
    {
      // sort queries by value
      // BFS to grab all elements less than query

      var diffs = new List<(int x, int y)>
    {
      (0, 1),
      (0, -1),
      (1, 0),
      (-1, 0),
    };

      var visited = new HashSet<(int x, int y)>();

      var queue = new PriorityQueue<(int x, int y), int>();
      queue.Enqueue((0, 0), grid[0][0]);

      var ans = new int[queries.Length];
      var qindexes = queries.Select((e, i) => (e, i)).OrderBy(m => m.e).ToArray();

      foreach (var qi in qindexes)
      {
        var max = qi.e;

        while (queue.Count > 0)
        {
          var el = queue.Dequeue();
          if (grid[el.x][el.y] >= max)
          {
            queue.Enqueue(el, grid[el.x][el.y]);
            break;
          }

          visited.Add(el);

          var next = GetNext(grid, el);

          foreach (var point in next)
          {
            if (!visited.Contains(point))
              queue.Enqueue(point, grid[point.x][point.y]);
          }
        }

        ans[qi.i] = visited.Count;
      }

      return ans;

      List<(int x, int y)> GetNext(int[][] grid, (int x, int y) el)
      {
        var n = grid.Length;
        var m = grid[0].Length;

        var result = new List<(int, int)>();

        foreach (var diff in diffs)
        {
          var point = (x: el.x + diff.x, y: el.y + diff.y);
          if (point.x >= 0 && point.y >= 0 && point.x < n && point.y < m)
          {
            result.Add(point);
          }
        }

        return result;
      }
    }
  }
}
