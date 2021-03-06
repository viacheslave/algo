namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/range-addition-ii/
///    Submission: https://leetcode.com/submissions/detail/231081468/
/// </summary>
internal class P0598
{
  public class Solution
  {
    public int MaxCount(int m, int n, int[][] ops)
    {
      var minX = m;
      var minY = n;

      var count = 0;

      foreach (var op in ops)
      {
        if (op[0] < minX) minX = op[0];
        if (op[1] < minY) minY = op[1];

        count++;
      }

      return minX * minY;
    }
  }
}
