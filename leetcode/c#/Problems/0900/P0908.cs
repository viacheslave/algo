namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/smallest-range-i/
///    Submission: https://leetcode.com/submissions/detail/234897685/
/// </summary>
internal class P0908
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
