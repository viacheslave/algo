using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3508/
  ///    https://leetcode.com/submissions/detail/413288825/?from=/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3508/
  /// </summary>
  internal class Oct26
  {
    public class Solution
    {
      public double ChampagneTower(int poured, int query_row, int query_glass)
      {
        var rows = new List<double[]>();
        for (int i = 1; i <= 101; i++)
          rows.Add(new double[i]);

        rows[0][0] = poured;

        for (int i = 0; i < 100; i++)
        {
          for (int j = 0; j < rows[i].Length; j++)
          {
            if (rows[i][j] > 1)
            {
              rows[i + 1][j] += (rows[i][j] - 1) / 2d;
              rows[i + 1][j + 1] += (rows[i][j] - 1) / 2d;
              rows[i][j] = 1;
            }
          }
        }

        return rows[query_row][query_glass];
      }
    }
  }
}
