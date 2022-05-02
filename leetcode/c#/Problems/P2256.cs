namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-average-difference/
///    Submission: https://leetcode.com/submissions/detail/691737589/
/// </summary>
internal class P2256
{
  public class Solution
  {
    public int MinimumAverageDifference(int[] nums)
    {
      var avg = long.MaxValue;
      var ans = -1;

      var sum = nums.Select(x => (long)x).Sum();
      var running = 0L;

      for (var i = 0; i < nums.Length; i++)
      {
        running += nums[i];

        var a = Math.Abs(
          (long)Math.Floor(1d * running / (i + 1)) -
          (long)Math.Floor(nums.Length - 1 - i == 0 ? 0d : 1d * (sum - running) / (nums.Length - 1 - i)));

        if (a < avg)
        {
          avg = a;
          ans = i;
        }
      }

      return ans;
    }
  }
}
