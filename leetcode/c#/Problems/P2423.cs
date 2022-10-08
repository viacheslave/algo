namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/remove-letter-to-equalize-frequency/
///    Submission: https://leetcode.com/problems/remove-letter-to-equalize-frequency/submissions/815924198/
/// </summary>
internal class P2423
{
  public class Solution
  {
    public bool EqualFrequency(string word)
    {
      var chars = new Dictionary<char, int>();

      for (var c = 'a'; c <= 'z'; c++)
        chars[c] = 0;

      foreach (var ch in word)
        chars[ch]++;

      for (var c = 'a'; c <= 'z'; c++)
      {
        chars[c]--;

        if (chars.Values.Where(f => f != 0).Distinct().Count() == 1)
          return true;

        chars[c]++;
      }

      return false;
    }
  }
}
