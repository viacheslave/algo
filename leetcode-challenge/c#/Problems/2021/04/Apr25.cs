using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3720/
  /// 
  /// </summary>
  internal class Apr25
  {
    public class Solution
    {


      private struct Point
      {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
          X = x;
          Y = y;
        }
      }

      public void Rotate(int[][] matrix)
      {


        for (var x = 0; x < matrix.Length / 2; x++)
        {
          for (var y = x; y < matrix.Length - (x + 1); y++)
          {
            SwapCircle(matrix, x, y);
          }
        }

      }

      private void SwapCircle(int[][] matrix, int x, int y)
      {
        var length = matrix.Length - 1;

        Point current = new Point(x, y);
        Point next = GetNext(current.X, current.Y, length);
        Swap(matrix, current, next);

        current = next;
        next = GetNext(current.X, current.Y, length);
        Swap(matrix, current, next);

        current = next;
        next = GetNext(current.X, current.Y, length);
        Swap(matrix, current, next);
      }

      private void Swap(int[][] matrix, Point current, Point next)
      {
        var currentValue = matrix[current.X][current.Y];
        var nextValue = matrix[next.X][next.Y];

        matrix[current.X][current.Y] = nextValue;
        matrix[next.X][next.Y] = currentValue;
      }

      private Point GetNext(int x, int y, int length)
      {
        return new Point(length - y, x);
      }
    }
  }
}
