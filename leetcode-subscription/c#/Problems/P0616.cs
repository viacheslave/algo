using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/add-bold-tag-in-string/
  ///    Submission: https://leetcode.com/submissions/detail/451167267/
  ///    Facebook
  /// </summary>
  internal class P0616
  {
    public class Solution
    {
      public string AddBoldTag(string s, string[] dict)
      {
        var mask = new HashSet<int>();

        foreach (var word in dict)
          for (var i = 0; i < s.Length - word.Length + 1; i++)
            if (s.Substring(i, word.Length) == word)
              for (var k = 0; k < word.Length; k++)
                mask.Add(i + k);

        var sb = new StringBuilder();
        sb.Append(s[0]);

        for (var i = 1; i < s.Length; i++)
        {
          if (!mask.Contains(i) && mask.Contains(i - 1))
            sb.Append("</b>");

          if (mask.Contains(i) && !mask.Contains(i - 1))
            sb.Append("<b>");

          sb.Append(s[i]);
        }

        if (mask.Contains(0))
          sb.Insert(0, "<b>");

        if (mask.Contains(s.Length - 1))
          sb.Append("</b>");

        return sb.ToString();
      }
    }
  }
}
