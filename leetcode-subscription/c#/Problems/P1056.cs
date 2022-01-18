using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/confusing-number/
  ///    Submission: https://leetcode.com/submissions/detail/450759823/
  ///    Google
  /// </summary>
  internal class P1056
  {
    public class Solution
    {
      public bool ConfusingNumber(int N)
      {
        var map = new Dictionary<int, int>
        {
          [0] = 0,
          [1] = 1,
          [6] = 9,
          [8] = 8,
          [9] = 6,
        };

        var digits = N.ToString().ToCharArray().Select(s => int.Parse(s.ToString()));

        if (digits.Any(d => !map.ContainsKey(d)))
          return false;

        var rev = digits.Reverse().Select(d => map[d]).ToArray();
        if (string.Join("", rev) != N.ToString())
          return true;

        return false;
      }
    }
  }
}
