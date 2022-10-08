namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-sum-of-an-hourglass/
///    Submission: https://leetcode.com/problems/maximum-sum-of-an-hourglass/submissions/816440250/
/// </summary>
internal class P2428
{
  public class Solution
  {
    public int MaxSum(int[][] grid)
    {
      var max = int.MinValue;

      for (int i = 0; i < grid.Length - 2; i++)
      {
        for (int j = 0; j < grid[0].Length - 2; j++)
        {
          var sum = grid[i][j] + grid[i][j + 1] + grid[i][j + 2]
            + grid[i + 1][j + 1]
            + grid[i + 2][j] + grid[i + 2][j + 1] + grid[i + 2][j + 2];

          max = Math.Max(max, sum);
        }
      }

      return max;
    }
  }
}
