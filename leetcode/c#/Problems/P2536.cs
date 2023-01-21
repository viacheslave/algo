namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/increment-submatrices-by-one/
///    Submission: https://leetcode.com/problems/increment-submatrices-by-one/submissions/880624742/
/// </summary>
internal class P2536
{
  public class Solution
  {
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
      var arrs = new int[n][];

      for (int i = 0; i < n; i++)
        arrs[i] = new int[n + 1];

      foreach (var query in queries)
      {
        var p1 = (query[0], query[1]);
        var p2 = (query[2], query[3]);

        for (int r = 0; r < n; r++)
        {
          if (p1.Item1 <= r && r <= p2.Item1)
          {
            arrs[r][p1.Item2]++;
            arrs[r][p2.Item2 + 1]--;
          }
        }
      }

      var ans = new int[n][];

      for (int i = 0; i < n; i++)
      {
        var running = 0;
        ans[i] = new int[n];

        for (int j = 0; j < n; j++)
        {
          running += arrs[i][j];
          ans[i][j] = running;
        }
      }

      return ans;
    }
  }
}
