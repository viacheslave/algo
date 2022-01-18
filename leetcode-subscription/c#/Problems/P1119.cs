using System;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/remove-vowels-from-a-string/
  ///    Submission: https://leetcode.com/submissions/detail/451158412/
  ///    Amazon
  /// </summary>
  internal class P1119
  {
    public class Solution
    {
      public string RemoveVowels(string s)
      {
        var sb = new StringBuilder(s);

        sb
          .Replace("a", "")
          .Replace("e", "")
          .Replace("i", "")
          .Replace("o", "")
          .Replace("u", "");

        return sb.ToString();
      }
    }
  }
}
