using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/573/week-5-december-29th-december-31st/3586/
  ///    https://leetcode.com/submissions/detail/436338177/?from=explore&item_id=3586
  /// </summary>
  internal class Dec30
  {
    public class Solution
    {
      public void GameOfLife(int[][] board)
      {
        var next = new int[board.Length][];

        for (int i = 0; i < board.Length; i++)
        {
          next[i] = new int[board[i].Length];

          for (int j = 0; j < board[i].Length; j++)
          {
            var num = GetNCount(board, i, j);

            if (board[i][j] == 1)
            {
              if (num < 2) next[i][j] = 0;
              else if (num > 3) next[i][j] = 0;
              else next[i][j] = 1;
            }
            else
            {
              if (num == 3) next[i][j] = 1;
            }
          }
        }

        for (int i = 0; i < board.Length; i++)
        {
          for (int j = 0; j < board[i].Length; j++)
          {
            board[i][j] = next[i][j];
          }
        }
      }

      private int GetNCount(int[][] board, int i, int j)
      {
        var neibs = new List<(int, int)>()
        {
            (i - 1, j - 1),
            (i - 1, j),
            (i - 1, j + 1),
            (i,     j + 1),
            (i + 1, j + 1),
            (i + 1, j),
            (i + 1, j - 1),
            (i, j - 1)
        };

        return neibs.Where(_ => IsValid(board, _)).Count();
      }

      private bool IsValid(int[][] board, (int, int) _)
      {
        return _.Item1 >= 0
            && _.Item2 >= 0
            && _.Item1 < board.Length
            && _.Item2 < board[0].Length
            && board[_.Item1][_.Item2] == 1;
      }
    }
  }
}
