using System.Collections.Generic;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3614/
  ///    https://leetcode.com/submissions/detail/447102283/?from=explore&item_id=3614
  /// </summary>
  internal class Jan23
  {
    public class Solution
    {
      public int[][] DiagonalSort(int[][] mat)
      {
        for (var col = 0; col < mat[0].Length; col++)
          Sort(mat, (0, col));

        for (var row = 0; row < mat.Length; row++)
          Sort(mat, (row, 0));

        return mat;
      }

      private void Sort(int[][] mat, (int row, int col) point)
      {
        var originalPoint = point;

        var list = new List<int>();
        while (true)
        {
          list.Add(mat[point.row][point.col]);
          point = (point.row + 1, point.col + 1);

          if (point.row == mat.Length || point.col == mat[0].Length)
            break;
        }

        list.Sort();

        point = originalPoint;
        foreach (var item in list)
        {
          mat[point.row][point.col] = item;
          point = (point.row + 1, point.col + 1);
        }
      }
    }
  }
}

