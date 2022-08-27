namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/max-sum-of-rectangle-no-larger-than-k/
///    Submission: https://leetcode.com/submissions/detail/784711088/
/// </summary>
internal class P0363
{
  public class Solution
  {
    public int MaxSumSubmatrix(int[][] matrix, int k)
    {
      var m = matrix.Length;
      var n = matrix[0].Length;

      // 2d prefix sum

      var prefixSum = new int[m, n];

      for (int i = 0; i < m; i++)
      {
        for (int j = 0; j < n; j++)
        {
          prefixSum[i, j] = matrix[i][j];

          if (i == 0 && j == 0)
          {
            continue;
          }

          if (i == 0)
          {
            prefixSum[i, j] += prefixSum[i, j - 1];
            continue;
          }

          if (j == 0)
          {
            prefixSum[i, j] += prefixSum[i - 1, j];
            continue;
          }

          prefixSum[i, j] = matrix[i][j]
            + prefixSum[i, j - 1]
            + prefixSum[i - 1, j]
            - prefixSum[i - 1, j - 1];
        }
      }

      var ans = int.MinValue;

      for (int i = 0; i < m; i++)
      {
        for (int j = 0; j < n; j++)
        {
          for (int ii = i; ii < m; ii++)
          {
            for (int jj = j; jj < n; jj++)
            {
              var p1 = (i, j);
              var p2 = (ii, jj);

              var sum = GetSum(prefixSum, p1, p2);

              if (sum > ans && sum <= k)
              {
                ans = sum;
              }
            }
          }
        }
      }

      return ans;
    }

    private int GetSum(int[,] prefixSum, (int i, int j) p1, (int ii, int jj) p2)
    {
      if (p1 == (0, 0))
        return prefixSum[p2.ii, p2.jj];

      if (p1.i == 0)
        return prefixSum[p2.ii, p2.jj] - prefixSum[p2.ii, p1.j - 1];

      if (p1.j == 0)
        return prefixSum[p2.ii, p2.jj] - prefixSum[p1.i - 1, p2.jj];

      return prefixSum[p2.ii, p2.jj]
        - prefixSum[p2.ii, p1.j - 1]
        - prefixSum[p1.i - 1, p2.jj]
        + prefixSum[p1.i - 1, p1.j - 1];
    }
  }
}
