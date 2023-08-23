namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-triangular-sum-of-an-array/
///    Submission: https://leetcode.com/submissions/detail/675927936/
/// </summary>
internal class P2221
{
  public class Solution
  {
    public int TriangularSum(int[] nums)
    {
      for (var i = nums.Length - 2; i >= 0; i--)
      {
        for (var j = 0; j <= i; j++)
        {
          nums[j] = (nums[j] + nums[j + 1]) % 10;
        }
      }

      return nums[0];
    }
  }
}
