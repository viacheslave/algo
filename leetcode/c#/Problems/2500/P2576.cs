namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-maximum-number-of-marked-indices/
///    Submission: https://leetcode.com/problems/find-the-maximum-number-of-marked-indices/submissions/917485838/
/// </summary>
internal class P2576
{
  public class Solution
  {
    public int MaxNumOfMarkedIndices(int[] nums)
    {
      Array.Sort(nums);

      // binary search
      var lo = 0;
      var hi = nums.Length / 2;

      while (lo < hi)
      {
        var mid = (lo + hi + 1) / 2;
        if (CanBeMarked(nums, mid))
        {
          lo = mid;
        }
        else
        {
          hi = mid - 1;
        }
      }

      return lo * 2;
    }

    private bool CanBeMarked(int[] nums, int k)
    {
      var ans = true;

      for (int i = 0; i < k; i++)
      {
        ans = ans && (nums[i] * 2 <= nums[nums.Length - k + i]);
        if (!ans)
          return false;
      }

      return true;
    }
  }
}
