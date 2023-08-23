namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/snakes-and-ladders/
///    Submission: https://leetcode.com/problems/snakes-and-ladders/submissions/865836113/
/// </summary>
internal class P0909
{
  public class Solution
  {
    public int SnakesAndLadders(int[][] board)
    {
      // convert to arr
      var n = board.Length;
      var arr = new List<int>();

      var order = 1;
      for (int i = n - 1; i >= 0; i--)
      {
        if (order == 1)
        {
          for (int j = 0; j < n; j++)
            arr.Add(board[i][j]);
        }
        else
        {
          for (int j = n - 1; j >= 0; j--)
            arr.Add(board[i][j]);
        }

        order = -order;
      }

      // BFS
      var queue = new Queue<(int from, int steps)>();
      queue.Enqueue((0, 0));

      var visited = new HashSet<int>();

      while (queue.Count > 0)
      {
        var el = queue.Dequeue();
        if (el.from >= n * n - 1)
        {
          return el.steps;
        }

        visited.Add(el.from);

        for (var i = 1; i <= 6; i++)
        {
          var next = el.from + i;

          if (next < arr.Count && arr[next] != -1)
          {
            next = arr[next] - 1;
          }

          if (visited.Contains(next))
          {
            continue;
          }

          queue.Enqueue((next, el.steps + 1));
        }
      }

      return -1;
    }
  }
}
