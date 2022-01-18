namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-whether-two-strings-are-almost-equivalent/
///    Submission: https://leetcode.com/submissions/detail/586578557/
/// </summary>
internal class P2068
{
  public class Solution
  {
    public bool CheckAlmostEquivalent(string word1, string word2)
    {
      var m1 = new Dictionary<char, int>();
      var m2 = new Dictionary<char, int>();

      for (var i = 'a'; i <= 'z'; i++)
      {
        m1[i] = 0;
        m2[i] = 0;
      }

      foreach (var ch in word1)
        m1[ch]++;

      foreach (var ch in word2)
        m2[ch]++;

      for (var i = 'a'; i <= 'z'; i++)
        if (Math.Abs(m1[(char)i] - m2[(char)i]) > 3)
          return false;

      return true;
    }
  }
}
