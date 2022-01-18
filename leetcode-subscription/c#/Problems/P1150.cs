using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/check-if-a-number-is-majority-element-in-a-sorted-array/
  ///    Submission: https://leetcode.com/submissions/detail/451453296/
  ///    Facebook
  /// </summary>
  internal class P1150
  {
    public class Solution
    {
      public bool IsMajorityElement(int[] nums, int target)
      {
        return nums.Count(n => n == target) > nums.Length / 2;
      }
    }
  }
}
