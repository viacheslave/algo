namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-all-groups-of-farmland/
///    Submission: https://leetcode.com/submissions/detail/551060145/
/// </summary>
internal class P1992
{
  public class Solution
  {
    public int[][] FindFarmland(int[][] land)
    {
      var visited = new HashSet<(int r, int c)>();
      var rows = land.Length;
      var cols = land[0].Length;

      var ans = new List<(int lr, int lc, int rr, int rc)>();

      for (var r = 0; r < rows; r++)
      {
        for (var c = 0; c < cols; c++)
        {
          if (land[r][c] == 0)
            continue;

          if (visited.Contains((r, c)))
            continue;

          var items = new HashSet<(int r, int c)>();
          var queue = new Queue<(int r, int c)>();
          queue.Enqueue((r, c));

          var minr = int.MaxValue;
          var minc = int.MaxValue;
          var maxr = int.MinValue;
          var maxc = int.MinValue;

          while (queue.Count > 0)
          {
            var item = queue.Dequeue();
            if (visited.Contains(item))
              continue;

            visited.Add(item);
            items.Add(item);

            minr = Math.Min(minr, item.r);
            maxr = Math.Max(maxr, item.r);

            minc = Math.Min(minc, item.c);
            maxc = Math.Max(maxc, item.c);

            var next = new List<(int r, int c)>
              {
                (item.r + 1, item.c),
                (item.r - 1, item.c),
                (item.r, item.c + 1),
                (item.r, item.c - 1),
              };

            foreach (var ni in next)
              if (ni.r >= 0 && ni.c >= 0 && ni.r < rows && ni.c < cols)
                if (land[ni.r][ni.c] == 1)
                  queue.Enqueue(ni);
          }

          if (items.Count == (maxr - minr + 1) * (maxc - minc + 1))
            ans.Add((minr, minc, maxr, maxc));
        }
      }

      return ans.Select(a => new[] { a.lr, a.lc, a.rr, a.rc }).ToArray();
    }
  }
}
