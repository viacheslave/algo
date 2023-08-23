namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/sum-in-a-matrix/
///    Submission: https://leetcode.com/problems/sum-in-a-matrix/submissions/957533539/
/// </summary>
internal class P2679
{
  public class Solution
  {
    public int MatrixSum(int[][] nums)
    {
      var arrs = nums
        .Select(a => a.OrderByDescending(_ => _).ToArray())
        .ToList();

      var score = 0;

      for (int col = 0; col < arrs[0].Length; col++)
      {
        var max = 0;
        for (int row = 0; row < arrs.Count; row++)
        {
          max = Math.Max(max, arrs[row][col]);
        }

        score += max;
      }

      return score;
    }
  }
}
