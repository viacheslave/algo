namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/sum-of-matrix-after-queries/
///    Submission: https://leetcode.com/problems/sum-of-matrix-after-queries/submissions/973926941/
/// </summary>
internal class P2718
{
  public class Solution
  {
    public long MatrixSumQueries(int n, int[][] queries)
    {
      long ans = 0;

      var rows = new HashSet<int>();
      var cols = new HashSet<int>();

      foreach (var query in queries.Reverse())
      {
        if (query[0] == 0)
        {
          if (!rows.Contains(query[1]))
          {
            // row
            rows.Add(query[1]);
            ans += (n - cols.Count) * query[2];
          }
        }
        else
        {
          if (!cols.Contains(query[1]))
          {
            // col
            cols.Add(query[1]);
            ans += (n - rows.Count) * query[2];
          }
        }
      }

      return ans;
    }
  }
}
