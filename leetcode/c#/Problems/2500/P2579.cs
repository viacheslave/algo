namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-total-number-of-colored-cells/
///    Submission: https://leetcode.com/problems/count-total-number-of-colored-cells/submissions/917707453/
/// </summary>
internal class P2579
{
  public class Solution
  {
    public long ColoredCells(int n)
    {
      var k = 1L * n;
      return (2 * k - 1) * (2 * k - 1) - 4 * ((k - 1) * k / 2);
    }
  }
}
