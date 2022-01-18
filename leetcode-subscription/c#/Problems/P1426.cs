using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/counting-elements/
  ///    Submission: https://leetcode.com/submissions/detail/450751045/
  ///    DRW
  /// </summary>
  internal class P1426
  {
    public class Solution
    {
      public int CountElements(int[] arr)
      {
        var map = arr.ToHashSet();

        return arr
          .Where(a => map.Contains(a + 1))
          .Count();
      }
    }
  }
}
