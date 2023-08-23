namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-trailing-zeros-in-a-cornered-path/
///    Submission: https://leetcode.com/submissions/detail/682267163/
/// </summary>
internal class P2245
{
  public class Solution
  {
    public int MaxTrailingZeros(int[][] grid)
    {
      var n = grid.Length;
      var m = grid[0].Length;

      var factors = new (int, int)[n, m];

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < m; j++)
        {
          var b = grid[i][j];

          var fives = 0;
          var twos = 0;

          while (b % 5 == 0)
          {
            fives++;
            b = b / 5;
          }

          while (b % 2 == 0)
          {
            twos++;
            b = b / 2;
          }

          factors[i, j] = (fives, twos);
        }
      }

      // collect prefix sums
      // over rows
      // over cols

      var horiz = new (int, int)[n, m + 1];
      var vert = new (int, int)[n + 1, m];

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < m; j++)
        {
          horiz[i, j + 1] = (
            horiz[i, j].Item1 + factors[i, j].Item1,
            horiz[i, j].Item2 + factors[i, j].Item2);
        }
      }

      for (int j = 0; j < m; j++)
      {
        for (int i = 0; i < n; i++)
        {
          vert[i + 1, j] = (
            vert[i, j].Item1 + factors[i, j].Item1,
            vert[i, j].Item2 + factors[i, j].Item2);
        }
      }

      var ans = 0;
      //return ans;

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < m; j++)
        {
          var top = vert[i, j];
          var left = horiz[i, j];

          var bottom = (
            vert[n, j].Item1 - vert[i + 1, j].Item1,
            vert[n, j].Item2 - vert[i + 1, j].Item2
          );

          var right = (
            horiz[i, m].Item1 - horiz[i, j + 1].Item1,
            horiz[i, m].Item2 - horiz[i, j + 1].Item2
          );

          var point = factors[i, j];

          var value = 0;
          value = Math.Max(value, GetMin(top, left, point));
          value = Math.Max(value, GetMin(top, bottom, point));
          value = Math.Max(value, GetMin(top, right, point));
          value = Math.Max(value, GetMin(left, bottom, point));
          value = Math.Max(value, GetMin(left, right, point));
          value = Math.Max(value, GetMin(bottom, right, point));

          ans = Math.Max(ans, value);
        }
      }

      return ans;

      int GetMin((int, int) a, (int, int) b, (int, int) c)
      {
        return Math.Min(
          a.Item1 + b.Item1 + c.Item1,
          a.Item2 + b.Item2 + c.Item2);
      }
    }
  }

}
