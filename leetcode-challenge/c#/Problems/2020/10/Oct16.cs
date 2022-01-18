using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3497/
  ///    https://leetcode.com/submissions/detail/409366986/?from=/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3497/
  /// </summary>
  internal class Oct16
  {
    public class Solution 
    {
      public bool SearchMatrix(int[][] matrix, int target) 
      {
        if (matrix.Length == 0)
          return false;
        
        var row = -1;
        for (var i = 0; i < matrix.Length; i++)
        {
          if (i + 1 == matrix.Length)
          {
            row = i;
            break;
        }
          
          if (matrix[i][0] <= target && target < matrix[i + 1][0])
          {
            row = i;
            break;
          }
        }
        
        if (row == -1)
          return false;
        
        return new HashSet<int>(matrix[row]).Contains(target);
      }
    }
  }
}
