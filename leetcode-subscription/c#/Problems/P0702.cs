using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/search-in-a-sorted-array-of-unknown-size/
  ///    Submission: https://leetcode.com/submissions/detail/458082876/
  ///    Morgan Stanley
  /// </summary>
  internal class P0702
  {
    class Solution
    {
      public int Search(ArrayReader reader, int target)
      {
        var start = 0;
        var end = 0;

        for (var i = 1; i < int.MaxValue; i *= 2)
        {
          if (reader.Get(i) >= target)
          {
            end = i;
            break;
          }
        }

        // binary search
        while (true)
        {
          if (end - start <= 1)
          {
            if (reader.Get(start) == target)
              return start;
            if (reader.Get(end) == target)
              return end;
            return -1;
          }

          var mid = (start + end) / 2;
          if (reader.Get(mid) >= target)
            end = mid;
          else
            start = mid;
        }

        return -1;
      }

      public class ArrayReader
      {
        internal int Get(int mid)
        {
          throw new NotImplementedException();
        }
      }
    }
  }
}
