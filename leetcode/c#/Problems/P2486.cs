namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/append-characters-to-string-to-make-subsequence/
///    Submission: https://leetcode.com/problems/append-characters-to-string-to-make-subsequence/submissions/850597841/
/// </summary>
internal class P2486
{
  public class Solution
  {
    public int AppendCharacters(string s, string t)
    {
      var tindex = 0;
      var any = false;

      for (int sindex = 0; sindex < s.Length; sindex++)
      {
        if (t[tindex] == s[sindex])
        {
          any = true;

          tindex++;
          if (tindex == t.Length)
          {
            return 0;
          }
        }
      }

      if (!any)
        return t.Length;

      return t.Length - tindex;
    }
  }
}
