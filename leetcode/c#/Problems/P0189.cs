namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/rotate-array/
///    Submission: https://leetcode.com/submissions/detail/228458939/
/// </summary>
internal class P0189
{
  public class Solution
  {
    public void Rotate(int[] nums, int k)
    {
      if (k == 0)
        return;

      if (nums.Length < 2)
        return;

      k = k % nums.Length;

      var saved = new int[k];

      for (var i = 0; i < k; i++)
        saved[i] = nums[nums.Length - k + i];

      for (var i = 0; i < nums.Length - k; i++)
        nums[nums.Length - 1 - i] = nums[nums.Length - 1 - i - k];

      for (var i = 0; i < k; i++)
        nums[i] = saved[i];
    }

  }
}
