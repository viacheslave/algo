namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sliding-puzzle/
///    Submission: https://leetcode.com/submissions/detail/626023539/
/// </summary>
internal class P0773
{
  public class Solution
  {
    public int SlidingPuzzle(int[][] board)
    {
      var start = Encode(board);

      var target = Encode(new int[][]
      {
      new int[] { 1,2,3 },
      new int[] { 4,5,0 }
      });

      // bfs
      var queue = new Queue<(int value, int distance)>();
      var visited = new HashSet<int>();

      queue.Enqueue((start, 0));
      visited.Add(start);

      while (queue.Count > 0)
      {
        var el = queue.Dequeue();
        if (el.value == target)
          return el.distance;

        var next = GetNext(el.value);
        foreach (var item in next)
        {
          if (!visited.Contains(item))
          {
            queue.Enqueue((item, el.distance + 1));
            visited.Add(item);
          }
        }
      }

      return -1;
    }

    private List<int> GetNext(int value)
    {
      var board = Decode(value);

      var zero = (-1, -1);
      for (int i = 0; i < 2; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (board[i][j] == 0)
          {
            zero = (i, j);
            break;
          }
        }
      }

      var dx = new int[] { 0, 1, 0, -1 };
      var dy = new int[] { 1, 0, -1, 0 };

      var ans = new List<int>();

      for (int i = 0; i < 4; i++)
      {
        var px = zero.Item1 + dx[i];
        var py = zero.Item2 + dy[i];

        if (px < 0 || py < 0 || px >= 2 || py >= 3)
          continue;

        Swap(board, zero, (px, py));

        ans.Add(Encode(board));

        Swap(board, (px, py), zero);
      }

      return ans;
    }

    private void Swap(int[][] board, (int, int) zero, (int px, int py) p)
    {
      var temp = board[zero.Item1][zero.Item2];

      board[zero.Item1][zero.Item2] = board[p.px][p.py];

      board[p.px][p.py] = temp;
    }

    public int Encode(int[][] board)
    {
      var ans = 0;

      for (int i = 0; i < 2; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          var power = 4 * (i * 3 + j);
          var value = board[i][j] << power;

          ans += value;
        }
      }

      return ans;
    }

    public int[][] Decode(int ans)
    {
      int[] arr = new int[6];

      for (var i = 0; i < 6; i++)
      {
        var value = ans % 16;
        arr[i] = value;

        ans >>= 4;
      }

      var board = new int[2][];

      board[0] = new int[3];
      board[1] = new int[3];

      board[0][0] = arr[0];
      board[0][1] = arr[1];
      board[0][2] = arr[2];
      board[1][0] = arr[3];
      board[1][1] = arr[4];
      board[1][2] = arr[5];

      return board;
    }
  }

}
