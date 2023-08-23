namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-if-every-row-and-column-contains-all-numbers/
///    Submission: https://leetcode.com/submissions/detail/616265657/
/// </summary>
internal class P2133
{
  public class Solution
  {
    public bool CheckValid(int[][] matrix)
    {
      var n = matrix.Length;

      for (int i = 0; i < n; i++)
      {
        var rows = new SortedSet<int>();
        var cols = new SortedSet<int>();

        for (int j = 0; j < n; j++)
        {
          rows.Add(matrix[i][j]);
          cols.Add(matrix[j][i]);
        }

        if (rows.Min != 1 || rows.Max != n || rows.Count != n)
          return false;

        if (cols.Min != 1 || cols.Max != n || cols.Count != n)
          return false;
      }

      return true;
    }
  }
}
