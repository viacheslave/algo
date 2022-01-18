using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/dot-product-of-two-sparse-vectors/
  ///    Submission: https://leetcode.com/submissions/detail/451540637/
  ///    Facebook, Apple
  /// </summary>
  internal class P1570
  {
    public class SparseVector
    {
      private Dictionary<int, int> _values = new Dictionary<int, int>();
      private int _max;

      public Dictionary<int, int> Values => _values;
      public int Max => _max;

      public SparseVector(int[] nums)
      {
        for (int i = 0; i < nums.Length; i++)
        {
          if (nums[i] != 0)
            _values[i] = nums[i];
        }

        _max = nums.Length;
      }

      // Return the dotProduct of two sparse vectors
      public int DotProduct(SparseVector vec)
      {
        var ans = 0;

        for (var i = 0; i < vec.Max; i++)
        {
          _values.TryGetValue(i, out var v1);
          vec.Values.TryGetValue(i, out var v2);

          ans += v2 * v1;
        }

        return ans;
      }
    }

    // Your SparseVector object will be instantiated and called as such:
    // SparseVector v1 = new SparseVector(nums1);
    // SparseVector v2 = new SparseVector(nums2);
    // int ans = v1.DotProduct(v2);
  }
}
