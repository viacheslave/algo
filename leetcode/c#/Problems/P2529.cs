namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-count-of-positive-integer-and-negative-integer/
///    Submission: https://leetcode.com/problems/maximum-count-of-positive-integer-and-negative-integer/submissions/881958315/
/// </summary>
internal class P2529
{
  public class Solution
  {
    public int MaximumCount(int[] nums)
    {
      return Math.Max(nums.Count(n => n > 0), nums.Count(n => n < 0));
    }
  }
}
