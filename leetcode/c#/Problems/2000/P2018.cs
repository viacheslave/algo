namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-if-word-can-be-placed-in-crossword/
///    Submission: https://leetcode.com/submissions/detail/569566257/
/// </summary>
internal class P2018
{
  public class Solution
  {
    public bool PlaceWordInCrossword(char[][] board, string word)
    {
      var rowsMap = new Dictionary<int, List<(int, int)>>();
      var colsMap = new Dictionary<int, List<(int, int)>>();

      var rows = board.Length;
      var cols = board[0].Length;

      // rows
      for (var row = 0; row < rows; row++)
      {
        var start = -1;
        rowsMap.Add(row, new List<(int, int)>());

        for (var col = 0; col < cols; col++)
        {
          if (board[row][col] != '#')
          {
            if (start == -1)
              start = col;
          }
          else if (board[row][col] == '#')
          {
            if (start != -1)
            {
              rowsMap[row].Add((start, col - 1));
              start = -1;
            }
          }
        }

        if (board[row][cols - 1] != '#')
          rowsMap[row].Add((start, cols - 1));
      }

      // cols
      for (var col = 0; col < cols; col++)
      {
        var start = -1;
        colsMap.Add(col, new List<(int, int)>());

        for (var row = 0; row < rows; row++)
        {
          if (board[row][col] != '#')
          {
            if (start == -1)
              start = row;
          }
          else if (board[row][col] == '#')
          {
            if (start != -1)
            {
              colsMap[col].Add((start, row - 1));
              start = -1;
            }
          }
        }

        if (board[rows - 1][col] != '#')
          colsMap[col].Add((start, rows - 1));
      }

      var wordback = new string(word.Reverse().ToArray());

      // try fit horizontally
      foreach (var item in rowsMap)
      {
        foreach (var span in item.Value)
        {
          if (span.Item2 - span.Item1 + 1 == word.Length)
          {
            var ok = true;
            for (var index = span.Item1; index <= span.Item2; index++)
              ok = ok & (board[item.Key][index] == ' ' || board[item.Key][index] == word[index - span.Item1]);

            if (ok)
              return true;

            ok = true;
            for (var index = span.Item1; index <= span.Item2; index++)
              ok = ok & (board[item.Key][index] == ' ' || board[item.Key][index] == wordback[index - span.Item1]);

            if (ok)
              return true;
          }
        }
      }

      // try fit vertically
      foreach (var item in colsMap)
      {
        foreach (var span in item.Value)
        {
          if (span.Item2 - span.Item1 + 1 == word.Length)
          {
            var ok = true;
            for (var index = span.Item1; index <= span.Item2; index++)
              ok = ok & (board[index][item.Key] == ' ' || board[index][item.Key] == word[index - span.Item1]);

            if (ok)
              return true;

            ok = true;
            for (var index = span.Item1; index <= span.Item2; index++)
              ok = ok & (board[index][item.Key] == ' ' || board[index][item.Key] == wordback[index - span.Item1]);

            if (ok)
              return true;
          }
        }
      }

      return false;
    }
  }



}
