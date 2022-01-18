using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/check-if-array-is-sorted-and-rotated/
  ///    Submission: https://leetcode.com/submissions/detail/453164457/
  ///    SoundHound
  /// </summary>
  internal class P1752
  {
    public class Solution
    {
      public bool Check(int[] nums)
      {
        var rot = 0;
        var max = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
          if (nums[i] < nums[i - 1])
          {
            if (rot == 0) rot++;
            else return false;
          }

          max = Math.Max(max, nums[i]);
        }

        return rot == 0 || nums[^1] <= nums[0];
      }
    }
  }
}
