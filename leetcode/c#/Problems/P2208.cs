namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximize-number-of-subsequences-in-a-string
///    Submission: https://leetcode.com/problems/maximize-number-of-subsequences-in-a-string/submissions/868108274/
/// </summary>
internal class P2208
{
  public class Solution
  {
    public long MaximumSubsequenceCount(string text, string pattern)
    {
      // check if pattern elements are the same
      if (pattern[0] == pattern[1])
      {
        var count = text.Count(c => c == pattern[0]) + 1;

        // this is a new ch
        if (count == 1)
          return 0;

        // count all pairs
        return 1L * count * (count - 1) / 2;
      }

      // optimal is to add chars at the beginning or the end
      // pattern[0] at the beginning
      // pattern[1] at the end

      var sb = new StringBuilder(text);
      sb.Insert(0, pattern[0]);

      var ansBeginning = GetCount(sb, pattern);

      sb = new StringBuilder(text);
      sb.Append(pattern[1]);

      var ansEnd = GetCount(sb, pattern);

      return Math.Max(ansBeginning, ansEnd);
    }

    private long GetCount(StringBuilder sb, string pattern)
    {
      var exclude = 0L;
      var countB = 0L;
      var countE = 0L;

      for (int i = 0; i < sb.Length; i++)
      {
        countB += sb[i] == pattern[0] ? 1 : 0;
        countE += sb[i] == pattern[1] ? 1 : 0;
      }

      if (countB == 0 || countE == 0)
        return 0;

      var runningE = 0L;

      for (int i = 0; i < sb.Length; i++)
      {
        if (sb[i] == pattern[1]) runningE++;
        if (sb[i] == pattern[0]) exclude += runningE;
      }

      return (countB * countE) - exclude;
    }
  }
}
