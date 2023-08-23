namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-length-of-string-after-deleting-similar-ends/
///    Submission: https://leetcode.com/submissions/detail/589090614/
/// </summary>
internal class P1750
{
  public class Solution
  {
    public int MinimumLength(string s)
    {
      var f = 0;
      var e = s.Length - 1;

      if (f == e)
        return 1;

      // two pointers
      while (true)
      {
        if (s[f] != s[e])
          return e - f + 1;

        var f_ch = s[f];
        var e_ch = s[e];

        while (f < s.Length && s[f] == f_ch)
          f++;

        while (e >= 0 && s[e] == e_ch)
          e--;

        // case when all chars between pointers are the same 
        if (e <= f)
          return (f - e + 1) == 1 ? 1 : 0;
      }
    }
  }
}
