namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-the-number-of-fair-pairs/
///    Submission: https://leetcode.com/problems/count-the-number-of-fair-pairs/submissions/900932991/
/// </summary>
internal class P2563
{
  public class Solution
  {
    private int BisectLeft(int[] nums, int element)
    {
      var lo = 0;
      var hi = nums.Length;

      while (lo < hi)
      {
        var mid = (lo + hi) >> 1;
        if (nums[mid] < element)
        {
          lo = mid + 1;
        }
        else
        {
          hi = mid;
        }
      }

      return lo;
    }

    private int BisectRight(int[] nums, int element)
    {
      var lo = 0;
      var hi = nums.Length;

      while (lo < hi)
      {
        var mid = (lo + hi) >> 1;
        if (nums[mid] > element)
        {
          hi = mid;
        }
        else
        {
          lo = mid + 1;
        }
      }

      return lo;
    }

    public long CountFairPairs(int[] nums, int lower, int upper)
    {
      if (nums.Length == 1)
        return 0;

      Array.Sort(nums);

      var ans = 0L;

      for (var i = 0; i < nums.Length - 1; i++)
      {
        var bleft = BisectLeft(nums, lower - nums[i]);
        var bright = BisectRight(nums, upper - nums[i]);

        if (bright <= i)
          continue;

        if (bleft <= i)
          bleft = i + 1;

        ans += (bright - bleft);
      }

      return ans;
    }
  }
}
