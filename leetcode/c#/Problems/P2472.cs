namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-non-overlapping-palindrome-substrings/
///    Submission: https://leetcode.com/problems/maximum-number-of-non-overlapping-palindrome-substrings/submissions/842880897/
/// </summary>
internal class P2472
{
  public class Solution
  {
    public int MaxPalindromes(string s, int k)
    {
      // DP On2

      var dp = new int[s.Length];

      for (var i = k - 1; i < s.Length; i++)
      {
        if (i > 0)
          dp[i] = dp[i - 1];

        for (var j = i - k + 1; j >= 0; j--)
        {
          var isP = IsPalindrome(s.AsSpan().Slice(j, i - j + 1));
          if (isP)
          {
            dp[i] = Math.Max(dp[i], (j - 1 >= 0 ? dp[j - 1] : 0) + 1);
          }
        }
      }

      return dp[^1];
    }

    private bool IsPalindrome(ReadOnlySpan<char> sp)
    {
      for (int i = 0; i < sp.Length / 2; i++)
      {
        if (sp[i] != sp[sp.Length - 1 - i])
          return false;
      }

      return true;
    }
  }
}
