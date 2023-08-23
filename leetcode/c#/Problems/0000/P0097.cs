namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/interleaving-string/
///    Submission: https://leetcode.com/submissions/detail/587756115/
/// </summary>
internal class P0097
{
  public class Solution
  {
    public bool IsInterleave(string s1, string s2, string s3)
    {
      if (s1.Length + s2.Length != s3.Length)
        return false;

      if (s1 == "" && s2 == s3)
        return true;

      if (s2 == "" && s1 == s3)
        return true;

      var dp = new int[s1.Length + 1, s2.Length + 1];

      for (var i = 0; i < s1.Length; i++)
        dp[i + 1, 0] = (i == 0 || dp[i, 0] == 1) && s1[i] == s3[i] ? 1 : 0;

      for (var i = 0; i < s2.Length; i++)
        dp[0, i + 1] = (i == 0 || dp[0, i] == 1) && s2[i] == s3[i] ? 1 : 0;

      for (var i = 1; i <= s1.Length; i++)
      {
        for (int j = 1; j <= s2.Length; j++)
        {
          if (dp[i - 1, j] == 1 && s3[i + j - 1] == s1[i - 1])
            dp[i, j] = 1;

          if (dp[i, j - 1] == 1 && s3[i + j - 1] == s2[j - 1])
            dp[i, j] = 1;
        }
      }

      return dp[s1.Length, s2.Length] == 1;
    }
  }
}
