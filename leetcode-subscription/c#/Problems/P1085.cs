using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sum-of-digits-in-the-minimum-number/
  ///    Submission: https://leetcode.com/submissions/detail/451055430/
  ///    Amazon
  /// </summary>
  internal class P1085
  {
    public class Solution
    {
      public int SumOfDigits(int[] A)
      {
        if (A.Length == 0)
          return 0;

        Array.Sort(A);

        var min = A[0];
        var sum = 0;

        while (min > 0)
        {
          var digit = min % 10;

          min = min / 10;

          sum += digit;
        }

        return sum % 2 == 1 ? 0 : 1;
      }
    }
  }
}
