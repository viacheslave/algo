namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/first-completely-painted-row-or-column/
///    Submission: https://leetcode.com/problems/first-completely-painted-row-or-column/submissions/942640789/
/// </summary>
internal class P2661
{
  public class Solution
  {
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
      var rows = new int[mat.Length];
      var cols = new int[mat[0].Length];

      var map = new Dictionary<int, (int x, int y)>();

      for (int i = 0; i < mat.Length; i++)
        for (int j = 0; j < mat[0].Length; j++)
          map[mat[i][j]] = (i, j);

      for (var i = 0; i < arr.Length; i++)
      {
        var corr = map[arr[i]];

        rows[corr.x]++;
        cols[corr.y]++;

        if (rows[corr.x] == mat[0].Length || cols[corr.y] == mat.Length)
          return i;
      }

      // should not happen
      return -1;
    }
  }
}
