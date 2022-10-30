namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/odd-string-difference/
///    Submission: https://leetcode.com/problems/odd-string-difference/submissions/833211382/
/// </summary>
internal class P2451
{
  public class Solution
  {
    public string OddString(string[] words)
    {
      var diffs = new List<int[]>();

      foreach (var word in words)
      {
        var diff = new int[word.Length - 1];

        for (int i = 1; i < word.Length; i++)
        {
          diff[i - 1] = word[i] - word[i - 1];
        }

        diffs.Add(diff);
      }

      // check pairs
      // find common pattern

      int[] common = null;

      for (int i = 1; i < diffs.Count; i++)
      {
        var left = diffs[i];
        var right = diffs[i - 1];

        var cc = left.Zip(right).Count(t => t.First != t.Second);

        if (cc == 0)
        {
          common = left;
          break;
        }
      }

      // "az","za","az"
      if (common is null)
      {
        common = diffs[0];
      }

      // get outlier

      for (int i = 0; i < diffs.Count; i++)
      {
        var dl = 0;

        for (int j = 0; j < diffs[i].Length; j++)
        {
          if (diffs[i][j] != common[j]) dl++;
        }

        if (dl != 0)
        {
          return words[i];
        }
      }

      // shouldn't happen
      return string.Empty;
    }
  }
}
