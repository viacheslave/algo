using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3650/
  ///   
  /// </summary>
  internal class Feb23
  {
    public class Solution
    {
      public bool SearchMatrix(int[][] matrix, int target)
      {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        if (rows == 0 || cols == 0)
          return false;

        if (target < matrix[0][0] || matrix[rows - 1][cols - 1] < target)
          return false;

        var curcol = 0;
        var currow = 0;

        for (var i = 0; i < rows; i++)
        {
          if (target >= matrix[i][0])
          {
            currow = i;
            continue;
          }
          break;
        }

        while (currow >= 0 && curcol >= 0 && currow < rows && curcol < cols)
        {
          while (matrix[currow][curcol] > target && currow >= 0)
          {
            currow--;
            if (currow < 0)
              return false;
          }

          if (matrix[currow][curcol] == target)
            return true;

          curcol++;
        }

        return false;
      }
    }
  }
}
