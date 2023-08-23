namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/make-array-zero-by-subtracting-equal-amounts/
///    Submission: https://leetcode.com/submissions/detail/761678870/
/// </summary>
internal class P2357
{
  public class Solution
  {
    public int MinimumOperations(int[] nums)
    {
      return nums.Distinct().Where(x => x != 0).Count();
    }
  }
}
