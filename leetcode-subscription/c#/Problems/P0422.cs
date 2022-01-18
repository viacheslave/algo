using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/valid-word-square/
  ///    Submission: https://leetcode.com/submissions/detail/453169759/
  ///    Bloomberg
  /// </summary>
  internal class P0422
  {
    public class Solution
    {
      public bool ValidWordSquare(IList<string> words)
      {
        var cols = new List<string>();
        var maxLength = words.Max(d => d.Length);

        for (var col = 0; col < maxLength; col++)
        {
          var sb = new StringBuilder();

          for (var row = 0; row < words.Count; row++)
          {
            if (col < words[row].Length)
              sb.Append(words[row][col]);
          }

          cols.Add(sb.ToString());
        }

        for (var i = 0; i < words.Count; i++)
        {
          if (i < cols.Count && words[i] == cols[i])
            continue;
          else
            return false;
        }

        return true;
      }
    }
  }
}
