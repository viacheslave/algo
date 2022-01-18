using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/one-edit-distance/
  ///    Submission: https://leetcode.com/submissions/detail/451930887/
  ///    All
  /// </summary>
  internal class P0161
  {
    public class Solution
    {
      public bool IsOneEditDistance(string s, string t)
      {
        var lcss = LCSS(s, t);

        if (s == t)
          return false;

        if (Math.Abs(s.Length - t.Length) >= 2)
          return false;

        if (s.Length == t.Length)
        {
          var missing = 0;
          for (var i = 0; i < s.Length; i++)
            if (s[i] != t[i])
              missing++;

          return missing == 1;
        }

        return s.Length == lcss || t.Length == lcss;
      }

      public int LCSS(string str1, string str2)
      {
        var dp = new int[str1.Length + 1, str2.Length + 1];

        for (var i = 0; i <= str1.Length; i++)
          dp[i, 0] = 0;

        for (var j = 0; j <= str2.Length; j++)
          dp[0, j] = 0;

        for (var i = 0; i < str1.Length; i++)
          for (var j = 0; j < str2.Length; j++)
            dp[i + 1, j + 1] = str1[i] == str2[j]
                ? dp[i, j] + 1
                : dp[i + 1, j] > dp[i, j + 1]
                  ? dp[i + 1, j]
                  : dp[i, j + 1];

        return dp[str1.Length, str2.Length];
      }
    }
  }
}
