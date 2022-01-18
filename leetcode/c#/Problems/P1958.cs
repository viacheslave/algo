namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-if-move-is-legal/
///    Submission: https://leetcode.com/submissions/detail/538054378/
/// </summary>
internal class P1958
{
  public class Solution
  {
    public enum Outcome
    {
      Break,
      RetTrue,
      Continue
    }

    public bool CheckMove(char[][] board, int rMove, int cMove, char color)
    {
      var opColor = color == 'W' ? 'B' : 'W';

      // up
      if (rMove - 2 >= 0 && board[rMove - 1][cMove] == opColor)
      {
        for (int row = rMove - 2, col = cMove; row >= 0; row--)
        {
          var o = GetOutcome(board, row, col, color);
          if (o == Outcome.Break) break;
          if (o == Outcome.RetTrue) return true;
        }
      }

      // up-right
      if (rMove - 2 >= 0 && cMove + 2 < 8 && board[rMove - 1][cMove + 1] == opColor)
      {
        for (int row = rMove - 2, col = cMove + 2; row >= 0 && col < 8; row--, col++)
        {
          var o = GetOutcome(board, row, col, color);
          if (o == Outcome.Break) break;
          if (o == Outcome.RetTrue) return true;
        }
      }

      // right
      if (cMove + 2 < 8 && board[rMove][cMove + 1] == opColor)
      {
        for (int row = rMove, col = cMove + 2; col < 8; col++)
        {
          var o = GetOutcome(board, row, col, color);
          if (o == Outcome.Break) break;
          if (o == Outcome.RetTrue) return true;
        }
      }

      // down-right
      if (rMove + 2 < 8 && cMove + 2 < 8 && board[rMove + 1][cMove + 1] == opColor)
      {
        for (int row = rMove + 2, col = cMove + 2; row < 8 && col < 8; row++, col++)
        {
          var o = GetOutcome(board, row, col, color);
          if (o == Outcome.Break) break;
          if (o == Outcome.RetTrue) return true;
        }
      }

      // down
      if (rMove + 2 < 8 && board[rMove + 1][cMove] == opColor)
      {
        for (int row = rMove + 2, col = cMove; row < 8; row++)
        {
          var o = GetOutcome(board, row, col, color);
          if (o == Outcome.Break) break;
          if (o == Outcome.RetTrue) return true;
        }
      }

      // down-left
      if (rMove + 2 < 8 && cMove - 2 >= 0 && board[rMove + 1][cMove - 1] == opColor)
      {
        for (int row = rMove + 2, col = cMove - 2; row < 8 && col >= 0; row++, col--)
        {
          var o = GetOutcome(board, row, col, color);
          if (o == Outcome.Break) break;
          if (o == Outcome.RetTrue) return true;
        }
      }

      // left
      if (cMove - 2 >= 0 && board[rMove][cMove - 1] == opColor)
      {
        for (int row = rMove, col = cMove - 2; col >= 0; col--)
        {
          var o = GetOutcome(board, row, col, color);
          if (o == Outcome.Break) break;
          if (o == Outcome.RetTrue) return true;
        }
      }

      // up-left
      if (rMove - 2 >= 0 && cMove - 2 >= 0 && board[rMove - 1][cMove - 1] == opColor)
      {
        for (int row = rMove - 2, col = cMove - 2; row >= 0 && col >= 0; row--, col--)
        {
          var o = GetOutcome(board, row, col, color);
          if (o == Outcome.Break) break;
          if (o == Outcome.RetTrue) return true;
        }
      }

      return false;
    }

    public Outcome GetOutcome(char[][] board, int row, int col, char color)
    {
      if (board[row][col] == '.')
        return Outcome.Break;

      if (board[row][col] == color)
        return Outcome.RetTrue;

      return Outcome.Continue;
    }
  }
}
