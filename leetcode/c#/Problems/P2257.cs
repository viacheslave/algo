namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-unguarded-cells-in-the-grid/
///    Submission: https://leetcode.com/submissions/detail/691728141/
/// </summary>
internal class P2257
{
  public class Solution
  {
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
      var guardsSet = guards.Select(x => (x: x[0], y: x[1])).ToHashSet();
      var wallsSet = walls.Select(x => (x: x[0], y: x[1])).ToHashSet();

      var covered = new HashSet<(int, int)>();

      foreach (var guard in guardsSet)
      {
        // up
        var sx = guard.x;
        var sy = guard.y;

        while (sx - 1 >= 0 && !guardsSet.Contains((sx - 1, sy)) && !wallsSet.Contains((sx - 1, sy)))
        {
          covered.Add((sx - 1, sy));
          sx--;
        }

        // down
        sx = guard.x;
        sy = guard.y;

        while (sx + 1 < m && !guardsSet.Contains((sx + 1, sy)) && !wallsSet.Contains((sx + 1, sy)))
        {
          covered.Add((sx + 1, sy));
          sx++;
        }

        // left
        sx = guard.x;
        sy = guard.y;

        while (sy - 1 >= 0 && !guardsSet.Contains((sx, sy - 1)) && !wallsSet.Contains((sx, sy - 1)))
        {
          covered.Add((sx, sy - 1));
          sy--;
        }

        // right
        sx = guard.x;
        sy = guard.y;

        while (sy + 1 < n && !guardsSet.Contains((sx, sy + 1)) && !wallsSet.Contains((sx, sy + 1)))
        {
          covered.Add((sx, sy + 1));
          sy++;
        }
      }

      return m * n - covered.Count - guardsSet.Count - wallsSet.Count;
    }
  }
}
