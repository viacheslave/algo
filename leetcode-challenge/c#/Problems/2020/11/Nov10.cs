using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3526/
  ///    https://leetcode.com/submissions/detail/418762222/?from=/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3526/
  /// </summary>
  internal class Nov10
  {
    public class Solution
    {
      public int[][] FlipAndInvertImage(int[][] A)
      {
        var rows = A.Length;
        var cols = A[0].Length;

        var mod = new int[rows][];

        for (var i = 0; i < rows; i++)
        {
          if (mod[i] == null)
            mod[i] = new int[cols];

          for (var j = 0; j < cols; j++)
            mod[i][j] = 1 - A[i][cols - 1 - j];
        }

        return mod;
      }
    }
  }
}
