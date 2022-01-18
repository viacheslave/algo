using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/two-sum-iii-data-structure-design/
  ///    Submission: https://leetcode.com/submissions/detail/452797921/
  ///    LinkedIn
  /// </summary>
  internal class P0170
  {
    public class TwoSum
    {
      SortedList<(int value, long ticks), (int value, long ticks)> _s =
        new SortedList<(int value, long ticks), (int value, long ticks)>(new Comp());

      /** Initialize your data structure here. */
      public TwoSum()
      {

      }

      /** Add the number to an internal data structure.. */
      public void Add(int number)
      {
        var el = (number, DateTime.UtcNow.Ticks);

        _s.Add(el, el);
      }

      /** Find if there exists any pair of numbers which sum is equal to the value. */
      public bool Find(int value)
      {
        for (var i = 0; i < _s.Count; i++)
        {
          var j = BinarySearch(_s, value - _s.Keys[i].value);
          if (j == -1)
            continue;

          if (i == j)
            continue;

          return true;
        }

        return false;
      }

      private int BinarySearch(SortedList<(int value, long ticks), (int value, long ticks)> s, int limit)
      {
        var l = 0;
        var r = s.Count - 1;

        if (l == r)
        {
          if (_s.Keys[l].value == limit)
            return l;
          return -1;
        }

        while (true)
        {
          if (l + 1 == r)
          {
            if (_s.Keys[r].value == limit)
              return r;
            if (_s.Keys[l].value == limit)
              return l;
            return -1;
          }

          var mid = (l + r) / 2;
          if (_s.Keys[mid].value >= limit)
            r = mid;
          else
            l = mid;
        }
      }

      public class Comp : IComparer<(int value, long ticks)>
      {
        public int Compare((int value, long ticks) x, (int value, long ticks) y) =>
          x.value == y.value ? x.ticks.CompareTo(y.ticks) : x.value.CompareTo(y.value);
      }
    }
  }
}
