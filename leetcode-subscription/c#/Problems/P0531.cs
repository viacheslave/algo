using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/lonely-pixel-i/
  ///    Submission: https://leetcode.com/submissions/detail/451554180/
  ///    Google
  /// </summary>
  internal class P0531
  {
    public class Solution
    {
      public int FindLonelyPixel(char[][] picture)
      {
        var rows = picture.Length;
        var cols = picture[0].Length;

        var arrRow = new List<List<int>>();

        for (var i = 0; i < rows; i++)
        {
          var pixels = new List<int>();
          arrRow.Add(pixels);

          for (var j = 0; j < cols; j++)
          {
            if (picture[i][j] == 'B')
              pixels.Add(j);
          }
        }

        var ans = 0;

        for (var j = 0; j < cols; j++)
        {
          var count = 0;
          var row = -1;

          for (var i = 0; i < rows; i++)
          {
            if (picture[i][j] == 'B')
            {
              count++;
              row = i;
            }
          }

          if (count == 1)
          {
            var rowPixels = arrRow[row];
            if (rowPixels.Count == 1)
              ans++;
          }
        }

        return ans;
      }
    }
  }
}
