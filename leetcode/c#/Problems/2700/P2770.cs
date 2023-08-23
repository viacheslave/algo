namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-jumps-to-reach-the-last-index/
///    Submission: https://leetcode.com/problems/maximum-number-of-jumps-to-reach-the-last-index/submissions/1026661661/
/// </summary>
internal class P2770
{
  public class Solution
  {
    public int MaximumJumps(int[] nums, int target)
    {
      var dp = new int[nums.Length];

      dp[0] = 1;

      for (int i = 1; i < nums.Length; i++)
      {
        for (int j = 0; j < i; j++)
        {
          if (Math.Abs(nums[i] - nums[j]) <= target)
          {
            if (dp[j] > 0)
            {
              dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
          }
        }
      }

      if (dp[^1] == 1)
        return -1;

      return dp[^1] - 1;
    }
  }

}
