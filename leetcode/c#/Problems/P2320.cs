namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-number-of-ways-to-place-houses/
///    Submission: https://leetcode.com/submissions/detail/733228386/
/// </summary>
internal class P2320
{
  public class Solution
  {
    public int CountHousePlacements(int n)
    {
      var mod = (int)1e9 + 7;

      // DP
      var dp = new int[n][];

      dp[0] = new int[2];
      dp[0][0] = 1;
      dp[0][1] = 1;

      for (var i = 1; i < n; i++)
      {
        dp[i] = new int[2];

        // place house
        dp[i][1] = dp[i - 1][0];

        // no house
        dp[i][0] = dp[i - 1][0] + dp[i - 1][1];
        dp[i][0] = dp[i][0] % mod;
      }

      var ans = dp[n - 1][0] + dp[n - 1][1];

      return MultMod(ans, ans, mod);
    }

    private static int MultMod(int a, int b, int mod)
    {
      var res = 0;
      a %= mod;

      while (b > 0)
      {
        if ((b & 1) > 0)
          res = (res + a) % mod;

        a = (2 * a) % mod;
        b >>= 1;
      }

      return res;
    }
  }
}
