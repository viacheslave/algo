namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-if-matrix-is-x-matrix/
///    Submission: https://leetcode.com/submissions/detail/733237372/
/// </summary>
internal class P2319
{
  public class Solution
  {
    public bool CheckXMatrix(int[][] grid)
    {
      var n = grid.Length;
      var sum = grid.SelectMany(g => g).Sum();

      var diagSum = 0;

      for (var i = 0; i < n; i++)
      {
        if (grid[i][i] == 0 || grid[i][n - 1 - i] == 0)
          return false;

        diagSum += grid[i][i];

        if (i != n - 1 - i)
          diagSum += grid[i][n - 1 - i];
      }

      return sum == diagSum;
    }
  }
}
