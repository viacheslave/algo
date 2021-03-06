namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
///    Submission: https://leetcode.com/submissions/detail/230000224/
/// </summary>
internal class P0153
{
  public class Solution
  {
    public int FindMin(int[] nums)
    {
      if (nums.Length == 1)
        return nums[0];

      for (var i = 1; i < nums.Length; i++)
      {
        if (nums[i] < nums[i - 1])
          return nums[i];
      }

      return nums[0];
    }
  }
}
