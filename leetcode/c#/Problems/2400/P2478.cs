namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-beautiful-partitions/
///    Submission: https://leetcode.com/problems/number-of-beautiful-partitions/submissions/846960459/
/// </summary>
internal class P2478
{
  public class Solution
  {
    public int BeautifulPartitions(string s, int k, int minLength)
    {
      // 2D dp, top-down
      var dp = new int[k + 1, s.Length];

      for (int i = 0; i < k + 1; i++)
        for (int j = 0; j < s.Length; j++)
          dp[i, j] = -1;

      var ans = Get(k, s.Length - 1, dp, s, minLength);
      return ans;
    }

    private int Get(int segments, int index, int[,] dp, string s, int minLength)
    {
      if (index < 0)
        return 0;

      if (dp[segments, index] != -1)
        return dp[segments, index];

      if (segments == 1)
      {
        dp[segments, index] = (IsValidSegment(s, 0, index) && (index + 1) >= minLength) ? 1 : 0;
        return dp[segments, index];
      }

      const int mod = (int)1e9 + 7;
      var ans = 0;

      for (var i = index - minLength; i >= minLength - 1; i--)
      {
        if (IsValidSegment(s, i + 1, index))
        {
          ans += Get(segments - 1, i, dp, s, minLength);
          ans %= mod;
        }
      }

      dp[segments, index] = ans;
      return ans;
    }

    private static bool IsValidSegment(string s, int from, int to) => IsPrime(s[from]) && IsCompound(s[to]);
    private static bool IsPrime(char c) => c == '2' || c == '3' || c == '5' || c == '7';
    private static bool IsCompound(char c) => c == '1' || c == '4' || c == '6' || c == '8' || c == '9';
  }
}
