namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/partition-string-into-minimum-beautiful-substrings/
///    Submission: https://leetcode.com/problems/partition-string-into-minimum-beautiful-substrings/submissions/1026612349/
/// </summary>
internal class P2767
{
  public class Solution
  {
    public int MinimumBeautifulSubstrings(string s)
    {
      var powers = new HashSet<string>()
      {
        "1",
        "101",
        "11001",
        "1111101",
        "1001110001",
        "110000110101",
        "11110100001001",
      };

      var dp = new int[s.Length];
      dp[0] = s[0] == '1' ? 1 : 0;

      for (int i = 1; i < s.Length; i++)
      {
        dp[i] = powers.Contains(s[..(i + 1)]) ? 1 : 0;

        for (int j = 0; j < i; j++)
        {
          var slice = s.Substring(j + 1, i - j);
          if (powers.Contains(slice))
          {
            if (dp[j] == 0)
              continue;

            var value = dp[j] + 1;
            dp[i] = dp[i] == 0 ? value : Math.Min(dp[i], value);
          }
        }
      }

      return dp[^1] == 0 ? -1 : dp[^1];
    }
  }
}
