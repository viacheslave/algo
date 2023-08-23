namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-pivot-integer/
///    Submission: https://leetcode.com/problems/find-the-pivot-integer/submissions/850599804/
/// </summary>
internal class P2485
{
  public class Solution
  {
    public int PivotInteger(int n)
    {
      for (int i = 1; i <= n; i++)
      {
        var left = i * (i + 1) / 2;
        var right = (i == 1) ? (n * (n + 1) / 2) : ((n * (n + 1) / 2) - i * (i - 1) / 2);

        if (left == right)
          return i;
      }

      return -1;
    }
  }
}
