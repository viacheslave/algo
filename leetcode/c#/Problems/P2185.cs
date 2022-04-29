namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/counting-words-with-a-given-prefix/
///    Submission: https://leetcode.com/submissions/detail/689849610/
/// </summary>
internal class P2185
{
  public class Solution
  {
    public int PrefixCount(string[] words, string pref)
    {
      var ans = 0;

      foreach (var word in words)
      {
        if (word.Length < pref.Length)
          continue;

        var res = true;

        for (var i = 0; i < pref.Length; i++)
        {
          if (word[i] != pref[i])
          {
            res = false;
            break;
          }
        }

        if (res)
        {
          ans++;
        }
      }

      return ans;
    }
  }
}
