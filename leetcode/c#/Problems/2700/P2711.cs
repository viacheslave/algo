namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/difference-of-number-of-distinct-values-on-diagonals/
///    Submission: https://leetcode.com/problems/difference-of-number-of-distinct-values-on-diagonals/submissions/974183661/
/// </summary>
internal class P2711
{
  public class Solution
  {
    public int[][] DifferenceOfDistinctValues(int[][] grid)
    {
      var m = grid.Length;
      var n = grid[0].Length;

      var ans = new int[m][];
      for (int i = 0; i < m; i++)
        ans[i] = new int[n];

      // rows
      for (var i = 0; i < m; i++)
      {
        var shift = 0;
        var map = new Dictionary<int, int>();

        while (true)
        {
          var (x, y) = (x: i + shift, y: 0 + shift);
          if (x == m || y == n)
            break;

          map[grid[x][y]] = map.GetValueOrDefault(grid[x][y], 0) + 1;
          shift++;
        }

        var mapAcc = new Dictionary<int, int>();

        for (int s = 0; ; s++)
        {
          var (x, y) = (x: i + s, y: 0 + s);
          if (x == m || y == n)
            break;

          var value = grid[x][y];

          // remove
          map[value]--;
          if (map[value] == 0) map.Remove(value);

          ans[x][y] = Math.Abs(mapAcc.Keys.Count - map.Keys.Count);

          // add
          mapAcc[value] = mapAcc.GetValueOrDefault(value, 0) + 1;
        }
      }

      // cols
      for (var i = 0; i < n; i++)
      {
        var shift = 0;
        var map = new Dictionary<int, int>();

        while (true)
        {
          var (x, y) = (x: 0 + shift, y: i + shift);
          if (x == m || y == n)
            break;

          map[grid[x][y]] = map.GetValueOrDefault(grid[x][y], 0) + 1;
          shift++;
        }

        var mapAcc = new Dictionary<int, int>();

        for (int s = 0; ; s++)
        {
          var (x, y) = (x: 0 + s, y: i + s);
          if (x == m || y == n)
            break;

          var value = grid[x][y];

          // remove
          map[value]--;
          if (map[value] == 0) map.Remove(value);

          ans[x][y] = Math.Abs(mapAcc.Keys.Count - map.Keys.Count);

          // add
          mapAcc[value] = mapAcc.GetValueOrDefault(value, 0) + 1;
        }
      }

      return ans;
    }
  }
}
