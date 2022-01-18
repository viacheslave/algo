using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///	  https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/553/week-5-august-29th-august-31st/3441/
  ///	  https://leetcode.com/submissions/detail/387964684/?from=/explore/challenge/card/august-leetcoding-challenge/553/week-5-august-29th-august-31st/3441/
  /// </summary>
  internal class Aug29
  {
    public class Solution
    {
      public IList<int> PancakeSort(int[] A)
      {
        var list = A.ToList();
        var flips = new List<int>();

        for (var i = A.Length; i >= 1; i--)
        {
          if (A[i - 1] == i)
            continue;

          var index = Array.FindLastIndex(A, _ => _ == i);
          if (index != 0)
          {
            flips.Add(index + 1);
            Flip(A, index);
          }

          flips.Add(i);
          Flip(A, i - 1);
        }

        return flips;
      }

      private void Flip(int[] A, int index)
      {
        var list = new List<int>();
        for (var i = index; i >= 0; i--)
          list.Add(A[i]);

        for (var i = 0; i < list.Count; i++)
          A[i] = list[i];
      }
    }
  }
}
