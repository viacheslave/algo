using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3697/
  /// 
  /// </summary>
  internal class Apr05
  {
    public class Solution
    {
      public bool IsIdealPermutation(int[] A)
      {
        var sl = new SortedList<int, int>();

        var glob = 0;
        var local = 0;

        for (int i = A.Length - 1; i >= 0; i--)
        {
          sl.Add(A[i], 0);
          glob += sl.IndexOfKey(A[i]);
        }

        for (int i = A.Length - 1; i > 0; i--)
        {
          if (A[i - 1] > A[i])
            local++;
        }

        return glob == local;
      }
    }
  }
}
