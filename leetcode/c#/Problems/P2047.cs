namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-valid-words-in-a-sentence/
///    Submission: https://leetcode.com/submissions/detail/583502348/
/// </summary>
internal class P2047
{
  public class Solution
  {
    public int CountValidWords(string sentence)
    {
      var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
      return words.Count(IsValid);
    }

    private bool IsValid(string w)
    {
      var hyphens = new List<int>();
      var puncs = new List<int>();

      for (var i = 0; i < w.Length; i++)
      {
        if (w[i] == '-') hyphens.Add(i);
        if (w[i] == '.' || w[i] == ',' || w[i] == '!') puncs.Add(i);
        if (char.IsDigit(w[i]))
          return false;
      }

      if (hyphens.Count > 1)
        return false;

      foreach (var hi in hyphens)
      {
        if (hi == 0 || hi == w.Length - 1)
          return false;

        if (!char.IsLower(w[hi - 1]) || !char.IsLower(w[hi + 1]))
          return false;
      }

      if (puncs.Count > 1 || (puncs.Count == 1 && puncs[0] != w.Length - 1))
        return false;

      return true;
    }
  }
}
