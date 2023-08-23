namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-product-of-the-length-of-two-palindromic-subsequences/
///    Submission: https://leetcode.com/submissions/detail/588519529/
/// </summary>
internal class P2002
{
  public class Solution
  {
    public int MaxProduct(string s)
    {
      var max = (int)Math.Pow(2, s.Length);
      var ans = 1;

      for (var i = 0; i < max; i++) // 2^12
      {
        var binary = Convert.ToString(i, 2);
        if (binary.Length < s.Length)
          binary = new string('0', s.Length - binary.Length) + binary;

        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();

        for (var j = 0; j < s.Length; j++)
        {
          if (binary[j] == '0') sb1.Append(s[j]);
          else sb2.Append(s[j]);
        }

        if (sb1.Length == 0 || sb2.Length == 0)
          continue;

        var l1 = LongestPalindromeSubseq(sb1.ToString());
        var l2 = LongestPalindromeSubseq(sb2.ToString());

        ans = Math.Max(ans, l1 * l2);
      }

      return ans;
    }

    // copied from 
    // https://leetcode.com/submissions/detail/435981123/
    public int LongestPalindromeSubseq(string s)
    {
      if (s.Length == 1)
        return 1;

      var dp = new int[s.Length, s.Length];

      // answer for a single ch is 1
      for (var i = 0; i < s.Length - 1; i++)
        dp[i, i] = 1;

      for (var l = 1; l < s.Length; l++)
      {
        for (var i = 0; i < s.Length - l; i++)
        {
          var from = i;
          var to = from + l;

          // for length of two: 
          // if ch are equal: 2
          // otherwise: 1
          if (to - from == 1)
            dp[from, to] = s[from] == s[to] ? 2 : 1;

          // for length greater than 2:
          // if begin = end - take inside [from + 1, to + 1] + 2
          // otherwise take max of [from + 1, to], [from, to + 1]
          else
            dp[from, to] = s[from] == s[to]
              ? dp[from + 1, to - 1] + 2
              : Math.Max(dp[from + 1, to], dp[from, to - 1]);
        }
      }

      return dp[0, s.Length - 1];
    }
  }
}
