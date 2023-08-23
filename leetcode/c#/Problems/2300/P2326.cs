namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/spiral-matrix-iv/
///    Submission: https://leetcode.com/submissions/detail/737443182/
/// </summary>
internal class P2326
{
  public class Solution
  {
    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
      var ans = new int[m][];

      for (var i = 0; i < m; i++)
      {
        ans[i] = new int[n];
        Array.Fill(ans[i], -1);
      }

      var pos = (x: 0, y: 0);
      var inc = (x: 0, y: 1);

      var current = head;

      while (current != null)
      {
        ans[pos.x][pos.y] = current.val;

        var next = (x: pos.x + inc.x, y: pos.y + inc.y);
        if (IsOutOfBounds(m, n, next) || ans[next.x][next.y] != -1)
        {
          inc = inc switch
          {
            (0, 1) => (1, 0),
            (1, 0) => (0, -1),
            (0, -1) => (-1, 0),
            (-1, 0) => (0, 1),
          };

          next = (x: pos.x + inc.x, y: pos.y + inc.y);

          if (IsOutOfBounds(m, n, next))
            break;
        }

        if (ans[next.x][next.y] != -1)
        {
          break;
        }

        current = current.next;
        pos = next;
      }

      return ans;

      static bool IsOutOfBounds(int m, int n, (int x, int y) next)
      {
        return next.x < 0 || next.y < 0 || next.x >= m || next.y >= n;
      }
    }
  }
}
