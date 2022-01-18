namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/parallel-courses-iii/
///    Submission: https://leetcode.com/submissions/detail/581920496/
/// </summary>
internal class P2050
{
  public class Solution
  {
    public int MinimumTime(int n, int[][] relations, int[] time)
    {
      var neighbors = new Dictionary<int, List<int>>();
      for (var i = 0; i < n; i++)
        neighbors.Add(i, new List<int>());

      foreach (var relation in relations)
        neighbors[relation[0] - 1].Add(relation[1] - 1);

      // topological sort Kahn's
      var topological = new List<int>();
      var indegrees = new int[n];

      foreach (var relation in relations)
        indegrees[relation[1] - 1]++;

      var q = new Queue<int>();
      for (var i = 0; i < n; i++)
        if (indegrees[i] == 0)
          q.Enqueue(i);

      while (q.Count > 0)
      {
        var node = q.Dequeue();
        topological.Add(node);

        foreach (var nei in neighbors[node])
        {
          indegrees[nei]--;
          if (indegrees[nei] == 0)
            q.Enqueue(nei);
        }
      }

      // accumulate times in sorted order
      var t = new int[n];

      for (var i = 0; i < n; i++)
        t[i] = time[i];

      for (var i = 0; i < n; i++)
      {
        var node = topological[i];
        var next = neighbors[node];

        foreach (var nextnode in next)
        {
          t[nextnode] = Math.Max(t[nextnode], t[node] + time[nextnode]);
        }
      }

      return t.Max();
    }
  }
}
