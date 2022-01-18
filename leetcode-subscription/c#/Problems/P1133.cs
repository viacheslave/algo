using System;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-unique-number/
  ///    Submission: https://leetcode.com/submissions/detail/451174845/
  ///    Amazon
  /// </summary>
  internal class P1133
  {
    public class Solution
    {
      public int LargestUniqueNumber(int[] A)
      {
        var numbers = A.GroupBy(d => d)
          .Where(s => s.Count() == 1)
          .OrderByDescending(s => s.Key)
          .ToList();

        return numbers.Count == 0 ? -1 : numbers.First().Key;
      }
    }
  }
}
