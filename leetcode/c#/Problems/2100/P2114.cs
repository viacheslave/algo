namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-words-found-in-sentences/
///    Submission: https://leetcode.com/submissions/detail/606925605/
/// </summary>
internal class P2114
{
  public class Solution
  {
    public int MostWordsFound(string[] sentences)
    {
      var ans = 0;

      foreach (var s in sentences)
      {
        var words = s.Split(' ');
        ans = Math.Max(ans, words.Length);
      }

      return ans;
    }
  }
}
