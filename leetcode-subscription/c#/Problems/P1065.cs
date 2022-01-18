using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/index-pairs-of-a-string/
  ///    Submission: https://leetcode.com/submissions/detail/451014978/
  ///    Amazon
  /// </summary>
  internal class P1065
  {
    public class Solution
    {
      public int[][] IndexPairs(string text, string[] words)
      {
        var ans = new List<(int, int)>();

        foreach (var word in words)
        {
          var sb = text;

          for (var i = 0; i < sb.Length - word.Length + 1; i++)
          {
            var index = sb.Substring(i, word.Length) == word;
            if (index)
              ans.Add((i, i + word.Length - 1));
          }
        }

        return ans
          .OrderBy(x => x.Item1)
          .ThenBy(x => x.Item2)
          .Select(c => new int[] { c.Item1, c.Item2 }).ToArray();
      }
    }
  }
}
