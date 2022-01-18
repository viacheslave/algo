using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/armstrong-number/
  ///    Submission: https://leetcode.com/submissions/detail/451168692/
  ///    Amazon
  /// </summary>
  internal class P1134
  {
    public class Solution
    {
      public bool IsArmstrong(int N)
      {
        var digits = N.ToString().Select(d => int.Parse(d.ToString())).ToArray();
        var k = digits.Length;

        var ans = digits.Sum(d => (int)Math.Pow(d, k));
        return ans == N;
      }
    }
  }
}
