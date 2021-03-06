namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-subarray/
///    Submission: https://leetcode.com/submissions/detail/233351615/
/// </summary>
internal class P0053
{
  public class Solution
  {
    public int MaxSubArray(int[] nums)
    {
      var maxSum = nums[0];
      var currentSum = nums[0];

      for (var i = 1; i < nums.Length; i++)
      {
        currentSum = Math.Max(nums[i], currentSum + nums[i]);
        maxSum = Math.Max(maxSum, currentSum);
      }

      return maxSum;
    }
  }
}
