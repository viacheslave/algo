namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-prefixes-of-a-given-string/
///    Submission: https://leetcode.com/submissions/detail/692117518/
/// </summary>
internal class P2255
{
  public class Solution
  {
    public int CountPrefixes(string[] words, string s)
    {
      var ans = 0;

      foreach (var word in words)
      {
        var pr = true;

        for (var i = 0; i < word.Length; i++)
        {
          if (i >= s.Length)
          {
            pr = false;
            break;
          }

          pr &= (s[i] == word[i]);
        }

        if (pr)
        {
          ans++;
        }
      }

      return ans;
    }
  }
}
