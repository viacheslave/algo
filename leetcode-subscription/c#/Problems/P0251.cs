using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/flatten-2d-vector/
  ///    Submission: https://leetcode.com/submissions/detail/451933730/
  ///    Airbnb
  /// </summary>
  internal class P0251
  {
    public class Vector2D
    {
      private IEnumerator<int> _it;
      private bool _hasValue;

      public Vector2D(int[][] v)
      {
        _it = v.SelectMany(v => v.Select(r => r)).GetEnumerator();
        _hasValue = _it.MoveNext();
      }

      public int Next()
      {
        var cur = _it.Current;

        _hasValue = _it.MoveNext();

        return cur;
      }

      public bool HasNext()
      {
        return _hasValue;
      }
    }
  }
}
