namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-score-from-performing-multiplication-operations/
///    Submission: https://leetcode.com/submissions/detail/573916345/
/// </summary>
internal class P1770
{
  public class Solution
  {
    public int MaximumScore(int[] nums, int[] multipliers)
    {
      var dp = new Dictionary<(int, int), int>();
      var diff = nums.Length - multipliers.Length;

      for (var i = 0; i < nums.Length - diff + 1; i++)
        dp[(i, i + diff)] = 0;

      // bottom-up dp
      for (int d = diff, c = multipliers.Length - 1; d < nums.Length; d++, c--)
      {
        for (var i = 0; i < nums.Length - d; i++)
        {
          dp[(i, i + d + 1)] = Math.Max(
            multipliers[c] * nums[i] + dp[(i + 1, i + d + 1)],
            multipliers[c] * nums[i + d] + dp[(i, i + d + 1 - 1)]
          );
        }
      }

      return dp[(0, nums.Length)];
    }
  }
}
