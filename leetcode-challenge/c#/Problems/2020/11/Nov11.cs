using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3527/
  ///    
  /// </summary>
  internal class Nov11
  {
    public class Solution
    {
      public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
      {
        var d1 = GetLength(p1, p2);
        var d2 = GetLength(p2, p3);
        var d3 = GetLength(p3, p4);
        var d4 = GetLength(p4, p1);
        var d5 = GetLength(p1, p3);
        var d6 = GetLength(p2, p4);

        var arr = new double[] { d1, d2, d3, d4, d5, d6 };

        Array.Sort(arr);

        return arr[5] == arr[4] &&
            arr[0] == arr[1] &&
            arr[0] == arr[2] &&
            arr[0] == arr[3] &&
            arr[0] != arr[5];
      }

      double GetLength(int[] p1, int[] p2)
      {
        return Math.Sqrt(
            Math.Pow(p2[0] - p1[0], 2) +
            Math.Pow(p2[1] - p1[1], 2)
        );
      }
    }
  }
}
