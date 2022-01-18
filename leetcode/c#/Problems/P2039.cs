namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/the-time-when-the-network-becomes-idle/
///    Submission: https://leetcode.com/submissions/detail/588579855/
/// </summary>
internal class P2039
{
  public class Solution
  {
    public int NetworkBecomesIdle(int[][] edges, int[] patience)
    {
      var e = new Dictionary<int, List<int>>();
      for (int i = 0; i < edges.Length; i++)
      {
        var edge = edges[i];

        if (!e.ContainsKey(edge[0])) e.Add(edge[0], new List<int>());
        if (!e.ContainsKey(edge[1])) e.Add(edge[1], new List<int>());

        e[edge[0]].Add(edge[1]);
        e[edge[1]].Add(edge[0]);
      }

      // BFS
      // find shortest paths from root to data servers

      var paths = new int[patience.Length];
      var visited = new HashSet<int>();
      var queue = new Queue<(int v, int w)>();
      queue.Enqueue((0, 0));

      while (queue.Count > 0)
      {
        var el = queue.Dequeue();
        if (visited.Contains(el.v))
          continue;

        visited.Add(el.v);

        paths[el.v] = el.w;

        foreach (var i in e[el.v])
        {
          if (!visited.Contains(i))
            queue.Enqueue((i, el.w + 1));
        }
      }

      var ans = int.MinValue;

      // check received time for each server
      for (var i = 1; i < patience.Length; i++)
      {
        var p = paths[i] * 2;

        // patience is big enough
        if (p <= patience[i])
        {
          ans = Math.Max(ans, p);
          continue;
        }

        if (p % patience[i] == 0)
        {
          // take twice minus patience
          ans = Math.Max(ans, p + p - patience[i]);
        }
        else
        {
          ans = Math.Max(ans, p + p - p % patience[i]);
        }
      }

      return ans + 1;
    }
  }
}
