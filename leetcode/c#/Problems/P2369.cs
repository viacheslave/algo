namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-if-there-is-a-valid-partition-for-the-array/
///    Submission: https://leetcode.com/submissions/detail/773261056/
/// </summary>
internal class P2369
{
  public class Solution
  {
    public bool ValidPartition(int[] nums)
    {
      var dp = new bool[nums.Length];

      // DP

      for (var i = 0; i < nums.Length; i++)
      {
        if (i == 0)
        {
          dp[0] = false;
          continue;
        }

        if (i == 1)
        {
          dp[1] = (nums[0] == nums[1]);
          continue;
        }

        if (i == 2)
        {
          dp[2] = (
            (nums[0] == nums[1] && nums[0] == nums[2]) ||
            (nums[1] == nums[0] + 1 && nums[2] == nums[1] + 1));
          continue;
        }

        var c1 = (nums[i] == nums[i - 1] && dp[i - 2]);
        var c2 = (nums[i] == nums[i - 1] && nums[i - 1] == nums[i - 2] && dp[i - 3]);
        var c3 = (nums[i] == nums[i - 1] + 1 && nums[i - 1] == nums[i - 2] + 1 && dp[i - 3]);

        dp[i] = c1 || c2 || c3;
      }

      return dp[nums.Length - 1];
    }
  }
}
