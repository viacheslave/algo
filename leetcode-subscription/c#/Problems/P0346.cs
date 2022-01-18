using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/moving-average-from-data-stream/
  ///    Submission: https://leetcode.com/submissions/detail/451007009/
  ///    All
  /// </summary>
  internal class P0346
  {
    public class MovingAverage
    {
      private readonly int _size;
      private readonly List<int> _arr = new List<int>();
      private int _sum = 0;

      /** Initialize your data structure here. */
      public MovingAverage(int size)
      {
        _size = size;
      }

      public double Next(int val)
      {
        _arr.Add(val);

        _sum += val;

        if (_arr.Count > _size)
        {
          _sum -= _arr[_arr.Count - 1 - _size];
          return 1.0 * _sum / _size;
        }

        return 1.0 * _sum / _arr.Count;
      }
    }

    /**
     * Your MovingAverage object will be instantiated and called as such:
     * MovingAverage obj = new MovingAverage(size);
     * double param_1 = obj.Next(val);
     */
  }
}
