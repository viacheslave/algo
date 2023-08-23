namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-people-aware-of-a-secret/
///    Submission: https://leetcode.com/submissions/detail/737421644/
/// </summary>
internal class P2327
{
  public class Solution
  {
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
      var mod = (int)1e9 + 7;
      var dp = new int[n + 1][];

      // DP
      // dp[i][j] - numbe rof people who have known the secret for j days on i day.  

      dp[1] = new int[forget + 1];

      // 1st day - 1 man
      dp[1][1] = 1;

      for (var i = 2; i <= n; i++)
      {
        dp[i] = new int[forget + 1];

        for (var j = 1; j <= forget; j++)
        {
          if (j > i)
            break;

          // people who had known - keep the secret
          dp[i][j] = dp[i - 1][j - 1];

          if (j > delay)
          {
            // once the dalay passes - those people tell new people
            dp[i][1] += dp[i - 1][j - 1];
            dp[i][1] %= mod;
          }
        }
      }

      var ans = 0;

      for (var i = 1; i <= forget; i++)
      {
        ans += dp[n][i];
        ans %= mod;
      }

      return ans;
    }
  }
}
