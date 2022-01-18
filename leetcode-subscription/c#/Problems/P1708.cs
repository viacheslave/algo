using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-subarray-length-k/
  ///    Submission: https://leetcode.com/submissions/detail/450714191/
  ///    Google
  /// </summary>
  internal class P1708
  {
    public class Solution
    {
      public int[] LargestSubarray(int[] nums, int k)
      {
        var max = 0;
        var maxIndex = -1;

        for (var i = 0; i < nums.Length - k + 1; i++)
        {
          if (nums[i] > max)
          {
            max = Math.Max(max, nums[i]);
            maxIndex = i;
          }
        }

        return nums.Skip(maxIndex).Take(k).ToArray();
      }
    }
  }
}
