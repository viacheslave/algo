using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/two-sum-less-than-k/
  ///    Submission: https://leetcode.com/submissions/detail/452790311/
  ///    Amazon
  /// </summary>
  internal class P1099
  {
    public class Solution
    {
      public int TwoSumLessThanK(int[] nums, int k)
      {
        Array.Sort(nums);

        var ans = -1;

        for (var i = 0; i < nums.Length; i++)
        {
          var j = BinarySearch(nums, k - nums[i]);
          if (j == -1)
            continue;

          if (i == j)
            continue;

          ans = Math.Max(ans, nums[i] + nums[j]);
        }

        return ans;
      }

      private int BinarySearch(int[] nums, int limit)
      {
        var l = 0;
        var r = nums.Length - 1;

        if (l == r)
        {
          if (nums[l] < limit)
            return l;
          return -1;
        }

        while (true)
        {
          if (l + 1 == r)
          {
            if (nums[r] < limit)
              return r;
            if (nums[l] < limit)
              return l;
            return -1;
          }

          var mid = (l + r) / 2;
          if (nums[mid] >= limit)
            r = mid;
          else
            l = mid;
        }
      }
    }
  }
}
