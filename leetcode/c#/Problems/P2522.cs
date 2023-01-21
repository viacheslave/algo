namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/partition-string-into-substrings-with-values-at-most-k/
///    Submission: https://leetcode.com/problems/partition-string-into-substrings-with-values-at-most-k/submissions/873242625/
/// </summary>
internal class P2522
{
  public class Solution
  {
    public int MinimumPartition(string s, int k)
    {
      var dp = new int[s.Length];
      Array.Fill(dp, int.MaxValue);

      for (int i = 0; i < s.Length; i++)
      {
        var num = 0L;

        for (int j = i; j >= 0; j--)
        {
          long add = int.Parse(s[j].ToString()) + (long)Math.Pow(10, i - j);
          if (num + add <= k)
          {
            num += add;

            if (j == 0)
            {
              dp[i] = Math.Min(dp[i], 1);
            }
            else if (dp[j - 1] == int.MaxValue)
            {
              dp[i] = int.MaxValue;
            }
            else
            {
              dp[i] = Math.Min(dp[i], dp[j - 1] + 1);
            }

            continue;
          }

          break;
        }
      }

      return dp[^1] == int.MaxValue ? -1 : dp[^1];
    }
  }

}
