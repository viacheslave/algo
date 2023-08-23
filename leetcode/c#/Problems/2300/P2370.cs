namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-ideal-subsequence/
///    Submission: https://leetcode.com/submissions/detail/773350603/
/// </summary>
internal class P2370
{
  public class Solution
  {
    public int LongestIdealString(string s, int k)
    {
      var dp = new int[s.Length];

      var memo = new Dictionary<char, int>();

      // DP
      // O(N * 26)

      for (var i = 0; i < s.Length; i++)
      {
        dp[i] = 1;

        foreach (var m in memo)
        {
          if (Math.Abs(m.Key - s[i]) <= k)
          {
            dp[i] = Math.Max(dp[i], dp[m.Value] + 1);
          }
        }

        memo[s[i]] = i;
      }

      return dp.Max();
    }
  }
}
