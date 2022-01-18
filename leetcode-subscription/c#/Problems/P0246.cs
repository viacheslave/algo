using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/strobogrammatic-number/
  ///    Submission: https://leetcode.com/submissions/detail/450760743/
  ///    Facebook
  /// </summary>
  internal class P0246
  {
    public class Solution
    {
      public bool IsStrobogrammatic(string num)
      {
        var map = new Dictionary<int, int>
        {
          [0] = 0,
          [1] = 1,
          [6] = 9,
          [8] = 8,
          [9] = 6,
        };

        var digits = num.ToString().ToCharArray().Select(s => int.Parse(s.ToString()));

        if (digits.Any(d => !map.ContainsKey(d)))
          return false;

        var rev = digits.Reverse().Select(d => map[d]).ToArray();

        return string.Join("", rev) == num.ToString();
      }
    }
  }
}
