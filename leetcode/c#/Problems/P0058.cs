namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/length-of-last-word/
///    Submission: https://leetcode.com/submissions/detail/226677785/
/// </summary>
internal class P0058
{
  public class Solution
  {
    public int LengthOfLastWord(string s)
    {
      var sp = s.Split(new[] { ' ' });

      for (var i = sp.Length - 1; i >= 0; i--)
        if (sp[i] != string.Empty)
          return sp[i].Length;

      return 0;
    }
  }
}
