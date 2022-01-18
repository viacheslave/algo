using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/614/week-2-august-8th-august-14th/3888/
  /// 
  /// </summary>
  internal class Aug13
  {
    public class Solution
    {
      public void SetZeroes(int[][] matrix)
      {

        var rows = new HashSet<int>();
        var cols = new HashSet<int>();

        for (var i = 0; i < matrix.Length; i++)
        {
          for (var j = 0; j < matrix[i].Length; j++)
          {
            if (matrix[i][j] == 0)
            {
              rows.Add(i);
              cols.Add(j);
            }
          }
        }

        foreach (var row in rows)
          for (var col = 0; col < matrix[0].Length; col++)
            matrix[row][col] = 0;


        foreach (var col in cols)
          for (var row = 0; row < matrix.Length; row++)
            matrix[row][col] = 0;
      }
    }
  }
}
