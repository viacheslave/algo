using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/perform-string-shifts/
  ///    Submission: https://leetcode.com/submissions/detail/451184079/
  ///    Goldman Sachs
  /// </summary>
  internal class P1427
  {
    public class Solution
    {
      public string StringShift(string s, int[][] shift)
      {
        foreach (var sh in shift)
        {
          if (sh[0] == 0)
            s = Left(s, sh[1]);
          else
            s = Right(s, sh[1]);
        }

        return s;
      }

      private string Left(string s, int k)
      {
        return s.Substring(k) + s.Substring(0, k);
      }

      private string Right(string s, int k)
      {
        return s.Substring(s.Length - k) + s.Substring(0, s.Length - k);
      }
    }
  }
}
