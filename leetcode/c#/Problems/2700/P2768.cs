namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/number-of-black-blocks/
///    Submission: https://leetcode.com/problems/number-of-black-blocks/submissions/1025940303/
/// </summary>
internal class P2768
{
  public class Solution
  {
    public long[] CountBlackBlocks(int m, int n, int[][] coordinates)
    {
      var dict = new Dictionary<(int, int), long>();
      var paths = new List<(int, int)>
      {
        (0,0),
        (0,-1),
        (-1,0),
        (-1,-1),
      };

      foreach (var coo in coordinates)
      {
        (int x, int y) = (coo[0], coo[1]);

        foreach (var path in paths)
        {
          var point = (x: x + path.Item1, y: y + path.Item2);
          if (point.x >= 0 && point.y >= 0 && point.x + 1 < m && point.y + 1 < n)
          {
            dict.TryAdd(point, 0);
            dict[point]++;
          }
        }
      }

      var ans = new long[5];

      for (int i = 0; i < ans.Length; i++)
      {
        if (i == 0)
          continue;

        ans[i] = dict.Count(d => d.Value == i);
      }

      ans[0] = 1L * (m - 1) * (n - 1) - ans.Sum();
      return ans;
    }
  }
}
