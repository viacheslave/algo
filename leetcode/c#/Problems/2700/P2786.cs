namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/visit-array-positions-to-maximize-score/
///    Submission: https://leetcode.com/problems/visit-array-positions-to-maximize-score/submissions/1030652993/
/// </summary>
internal class P2786
{
  public class Solution
  {
    public long MaxScore(int[] nums, int x)
    {
      var odd = -1;
      var even = -1;

      var dp = new long[nums.Length];
      dp[0] = nums[0];

      if (dp[0] % 2 == 0) even = 0;
      else odd = 0;

      for (int i = 1; i < nums.Length; i++)
      {
        long value = int.MinValue;

        if (nums[i] % 2 == 0)
        {
          if (even != -1)
            value = Math.Max(value, nums[i] + dp[even]);
          if (odd != -1)
            value = Math.Max(value, nums[i] + dp[odd] - x);

          even = i;
        }

        if (nums[i] % 2 == 1)
        {
          if (even != -1)
            value = Math.Max(value, nums[i] + dp[even] - x);
          if (odd != -1)
            value = Math.Max(value, nums[i] + dp[odd]);

          odd = i;
        }

        dp[i] = value;
      }

      return dp.Max();
    }
  }
}
