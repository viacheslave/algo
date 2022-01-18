using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/608/week-1-july-1st-july-7th/3803/
  /// 
  /// </summary>
  internal class Jul05
  {
    public class Solution
    {
      public int[][] MatrixReshape(int[][] nums, int r, int c)
      {
        if (nums.Length == 0)
          return nums;

        var s = nums[0].Length * nums.Length;
        if (s != r * c)
          return nums;


        int row = 0;
        int col = 0;

        int[][] res = new int[r][];

        for (var nr = 0; nr < nums.Length; nr++)
        {
          for (var nc = 0; nc < nums[nr].Length; nc++)
          {
            if (col == 0)
              res[row] = new int[c];

            res[row][col] = nums[nr][nc];
            col++;

            if (col == c)
            {
              col = 0;
              row++;
            }
          }
        }

        return res;
      }
    }
  }
}
