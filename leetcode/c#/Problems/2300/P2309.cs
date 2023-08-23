namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/greatest-english-letter-in-upper-and-lower-case/
///    Submission: https://leetcode.com/submissions/detail/725946364/
/// </summary>
internal class P2309
{
  public class Solution
  {
    public string GreatestLetter(string s)
    {
      var set = s.Distinct().ToHashSet();

      for (var i = 25; i >= 0; i--)
      {
        if (set.Contains((char)(i + 65)) && set.Contains((char)(i + 97)))
          return ((char)(i + 65)).ToString();
      }

      return "";
    }
  }
}
