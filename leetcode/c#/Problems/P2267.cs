namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-if-there-is-a-valid-parentheses-string-path/
///    Submission: https://leetcode.com/submissions/detail/695552797/
/// </summary>
internal class P2267
{
  public class Solution
  {
    public bool HasValidPath(char[][] grid)
    {
      var m = grid.Length;
      var n = grid[0].Length;

      var steps = m + n - 1;
      if (steps % 2 == 1)
      {
        return false;
      }

      var dp = new List<int>[m, n];

      // 0,0
      if (grid[0][0] == '(')
      {
        dp[0, 0] = new List<int> { 1 };
      }

      for (int r = 0; r < m; r++)
      {
        for (int c = 0; c < n; c++)
        {
          if (r == 0 && c == 0 && grid[0][0] == '(')
          {
            dp[0, 0] = new List<int> { 1 };
            continue;
          }

          var cells = new List<(int, int)>();

          if (r - 1 >= 0 && dp[r - 1, c] != null)
            cells.Add((r - 1, c));

          if (c - 1 >= 0 && dp[r, c - 1] != null)
            cells.Add((r, c - 1));

          if (cells.Count == 0)
          {
            dp[r, c] = null;
          }

          var list = new List<int>();

          foreach (var cell in cells)
          {
            var items = dp[cell.Item1, cell.Item2];

            foreach (var item in items)
            {
              if (grid[r][c] == '(')
              {
                list.Add(item + 1);
              }
              else
              {
                if (item - 1 >= 0)
                  list.Add(item - 1);
              }
            }
          }

          dp[r, c] = list.Distinct().ToList();
        }
      }

      return dp[m - 1, n - 1] != null && dp[m - 1, n - 1].Contains(0);
    }
  }

}
