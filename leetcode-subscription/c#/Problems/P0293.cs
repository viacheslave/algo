using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/flip-game/
  ///    Submission: https://leetcode.com/submissions/detail/450755647/
  ///    Google
  /// </summary>
  internal class P0293
  {
    public class Solution
    {
      public IList<string> GeneratePossibleNextMoves(string s)
      {
        if (s.Length < 2)
          return new List<string>();

        var ans = new List<string>();

        for (var i = 0; i < s.Length - 1; i++)
        {
          if (s[i] == '+' && s[i + 1] == '+')
          {
            var sb = new StringBuilder(s);
            sb[i] = '-';
            sb[i + 1] = '-';

            ans.Add(sb.ToString());
          }
        }

        return ans;
      }
    }
  }
}
