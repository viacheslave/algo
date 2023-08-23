namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-pairs-of-similar-strings/
///    Submission: https://leetcode.com/problems/count-pairs-of-similar-strings/submissions/862042069/
/// </summary>
internal class P2506
{
  public class Solution
  {
    public int SimilarPairs(string[] words)
    {
      var codes = new List<int>();

      foreach (var word in words)
      {
        var c = 0;

        foreach (var ch in word)
          c |= (1 << (ch - 97));

        codes.Add(c);
      }

      var ans = 0;

      for (var i = 0; i < words.Length - 1; i++)
      {
        for (var j = i + 1; j < words.Length; j++)
        {
          if (codes[i] == codes[j])
          {
            ans++;
          }
        }
      }

      return ans;
    }
  }
}
