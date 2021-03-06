namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sort-array-by-parity/
///    Submission: https://leetcode.com/submissions/detail/230916683/
/// </summary>
internal class P0905
{
  public class Solution
  {
    public int[] SortArrayByParity(int[] A)
    {
      return A.Where(_ => _ % 2 == 0).Concat(
          A.Where(_ => _ % 2 == 1))
          .ToArray();
    }
  }
}
