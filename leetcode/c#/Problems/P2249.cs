namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-lattice-points-inside-a-circle/
///    Submission: https://leetcode.com/submissions/detail/688004203/
/// </summary>
internal class P2249
{
  public class Solution
  {
    public int CountLatticePoints(int[][] circles)
    {
      var ans = 0;

      for (int x = 0; x <= 200; x++)
      {
        for (int y = 0; y <= 200; y++)
        {
          foreach (var circle in circles)
          {
            var cx = circle[0];
            var cy = circle[1];
            var cr = circle[2];

            var distance = Math.Sqrt((x - cx) * (x - cx) + (y - cy) * (y - cy));
            if (distance <= cr)
            {
              ans++;
              break;
            }
          }
        }
      }

      return ans;
    }
  }
}
