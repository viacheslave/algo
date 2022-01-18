using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/intersection-of-three-sorted-arrays/
  ///    Submission: https://leetcode.com/submissions/detail/451193794/
  ///    Facebook
  /// </summary>
  internal class P1213
  {
    public class Solution
    {
      public IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
      {
        return arr1.Concat(arr2).Concat(arr3)
          .GroupBy(a => a)
          .Where(x => x.Count() == 3)
          .Select(x => x.Key)
          .OrderBy(x => x)
          .ToList();
      }
    }
  }
}
