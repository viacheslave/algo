namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximize-the-topmost-element-after-k-moves/
///    Submission: https://leetcode.com/submissions/detail/690167322/
/// </summary>
internal class P2202
{
  public class Solution
  {
    public int MaximumTop(int[] nums, int k)
    {
      if (k % 2 == 1 && nums.Length == 1)
      {
        return -1;
      }

      var ans = int.MinValue;

      // take all-1 and put the max back
      for (var i = 0; i < Math.Min(k - 1, nums.Length); i++)
      {
        ans = Math.Max(ans, nums[i]);
      }

      // take all k, calculate max
      if (k < nums.Length)
      {
        ans = Math.Max(ans, nums[k]);
      }

      return ans;
    }
  }
}
