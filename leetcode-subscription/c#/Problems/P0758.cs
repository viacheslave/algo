using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/bold-words-in-string/
  ///    Submission: https://leetcode.com/submissions/detail/451166353/
  ///    Google
  /// </summary>
  internal class P0758
  {
    public class Solution
    {
      public string BoldWords(string[] words, string S)
      {
        var mask = new HashSet<int>();

        foreach (var word in words)
          for (var i = 0; i < S.Length - word.Length + 1; i++)
            if (S.Substring(i, word.Length) == word)
              for (var k = 0; k < word.Length; k++)
                mask.Add(i + k);

        var sb = new StringBuilder();
        sb.Append(S[0]);

        for (var i = 1; i < S.Length; i++)
        {
          if (!mask.Contains(i) && mask.Contains(i - 1))
            sb.Append("</b>");

          if (mask.Contains(i) && !mask.Contains(i - 1))
            sb.Append("<b>");

          sb.Append(S[i]);
        }

        if (mask.Contains(0))
          sb.Insert(0, "<b>");

        if (mask.Contains(S.Length - 1))
          sb.Append("</b>");

        return sb.ToString();
      }
    }
  }
}
