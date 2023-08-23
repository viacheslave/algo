namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/total-appeal-of-a-string/
///    Submission: https://leetcode.com/submissions/detail/691688783/
/// </summary>
internal class P2262
{
  public class Solution
  {
    public long AppealSum(string s)
    {
      var lastpos = new int[26];
      Array.Fill(lastpos, -1);

      var arr = new int[s.Length, 26];

      for (int i = 0; i < s.Length; i++)
      {
        var ch = s[i];

        lastpos[ch - 97] = i;

        for (int c = 0; c < 26; c++)
        {
          if (lastpos[c] != -1)
          {
            arr[i, c] = lastpos[c] + 1;
          }
        }
      }

      var ans = 0L;

      for (int i = 0; i < s.Length; i++)
      {
        for (int c = 0; c < 26; c++)
        {
          ans += arr[i, c];
        }
      }

      return ans;
    }
  }

}
