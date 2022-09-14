namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-rows-covered-by-columns/
///    Submission: https://leetcode.com/submissions/detail/797210749/
/// </summary>
internal class P2397
{
  public class Solution
  {
    public int MaximumRows(int[][] matrix, int numSelect)
    {
      // brute force

      var m = matrix.Length;
      var n = matrix[0].Length;
      var ans = 0;

      var ones = new int[m];

      for (int i = 0; i < m; i++)
      {
        ones[i] = matrix[i].Count(d => d == 1);
      }

      for (int mask = 0; mask < (1 << n); mask++)
      {
        var indices = new List<int>();

        var i = 0;
        var ma = mask;

        while (ma > 0)
        {
          if (ma % 2 == 1)
          {
            indices.Add(i);
          }

          ma >>= 1;
          i++;
        }

        if (indices.Count != numSelect)
        {
          continue;
        }

        var covered = 0;
        for (int r = 0; r < m; r++)
        {
          var o = 0;

          foreach (var j in indices)
          {
            if (matrix[r][j] == 1)
              o++;
          }

          var c = o == ones[r] || ones[r] == 0;
          if (c)
          {
            covered++;
          }
        }

        ans = Math.Max(ans, covered);
      }

      return ans;
    }
  }

}
