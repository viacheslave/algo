namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-artifacts-that-can-be-extracted/
///    Submission: https://leetcode.com/problems/count-artifacts-that-can-be-extracted/submissions/865891434/
/// </summary>
internal class P2201
{
  public class Solution
  {
    public int DigArtifacts(int n, int[][] artifacts, int[][] dig)
    {
      var digs = dig.Select(d => (x: d[0], y: d[1]))
        .ToHashSet();

      var ans = 0;

      foreach (var artifact in artifacts)
      {
        if (Found((x: artifact[0], y: artifact[1]), (x: artifact[2], y: artifact[3]), digs))
        {
          ans++;
        }
      }

      return ans;
    }

    private bool Found((int x, int y) tl, (int x, int y) br, HashSet<(int x, int y)> digs)
    {
      for (int i = tl.x; i <= br.x; i++)
      {
        for (int j = tl.y; j <= br.y; j++)
        {
          if (!digs.Contains((i, j)))
          {
            return false;
          }
        }
      }

      return true;
    }
  }
}
