namespace LeetCode.Naive.Problems;

/// <summary>
///   Problem: https://leetcode.com/problems/number-of-sets-of-k-non-overlapping-line-segments/
///   Submission: https://leetcode.com/submissions/detail/410263134/
/// </summary>
internal class P1621
{
  public class Solution
  {
    public int NumberOfSets(int n, int k)
    {
      n--;

      const int mod = (int)1e9 + 7;

      // [first] - x coord
      // [second] - line count
      // [third] - line start or not
      var dp = new int[n + 1, k + 1, 2];

      dp[0, 1, 1] = 1;

      for (var ni = 0; ni <= n; ++ni)
        dp[ni, 0, 0] = 1;

      for (var ni = 1; ni <= n; ++ni)
      {
        for (var ki = 1; ki <= k; ++ki)
        {
          dp[ni, ki, 1] = dp[ni - 1, ki - 1, 1];

          dp[ni, ki, 1] += dp[ni - 1, ki - 1, 0];
          dp[ni, ki, 1] %= mod;

          dp[ni, ki, 1] += dp[ni - 1, ki, 1];
          dp[ni, ki, 1] %= mod;

          dp[ni, ki, 0] =
            dp[ni - 1, ki, 1] +
            dp[ni - 1, ki, 0];

          dp[ni, ki, 0] %= mod;
        }
      }

      var ans = dp[n, k, 0];
      return ans;
    }
  }
}
