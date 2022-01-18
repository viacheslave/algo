using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/design-phone-directory/
  ///    Submission: https://leetcode.com/submissions/detail/451944046/
  ///    Google
  /// </summary>
  internal class P0379
  {
    public class PhoneDirectory
    {
      private readonly SortedSet<int> _numbers = new SortedSet<int>();
      private readonly SortedSet<int> _released = new SortedSet<int>();
      private readonly int _maxNumbers;

      /** Initialize your data structure here
          @param maxNumbers - The maximum numbers that can be stored in the phone directory. */
      public PhoneDirectory(int maxNumbers)
      {
        _maxNumbers = maxNumbers;
      }

      /** Provide a number which is not assigned to anyone.
          @return - Return an available number. Return -1 if none is available. */
      public int Get()
      {
        if (_released.Count > 0)
        {
          var r = _released.Min;
          _released.Remove(r);
          _numbers.Add(r);

          return r;
        }

        var n = _numbers.Count;

        if (n == _maxNumbers)
          return -1;

        _numbers.Add(n);
        return n;
      }

      /** Check if a number is available or not. */
      public bool Check(int number)
      {
        return !_numbers.Contains(number);
      }

      /** Recycle or release a number. */
      public void Release(int number)
      {
        if (_numbers.Contains(number))
        {
          _numbers.Remove(number);
          _released.Add(number);
        }
      }
    }
  }
}
