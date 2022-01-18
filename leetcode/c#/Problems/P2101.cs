namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/contest/biweekly-contest-67/problems/detonate-the-maximum-bombs/
///    Submission: https://leetcode.com/submissions/detail/600269252/
/// </summary>
internal class P2101
{
  public class Solution
  {
    public int MaximumDetonation(int[][] bombs)
    {
      var adj = new Dictionary<int, List<int>>();

      for (int i = 0; i < bombs.Length; i++)
      {
        adj.Add(i, new List<int>());
      }

      for (var i = 0; i < bombs.Length - 1; i++)
      {
        for (int j = i + 1; j < bombs.Length; j++)
        {
          var b1 = bombs[i];
          var b2 = bombs[j];

          var dist = Math.Sqrt(Math.Pow(b1[0] - b2[0], 2) + Math.Pow(b1[1] - b2[1], 2));

          if (dist <= b1[2])
            adj[i].Add(j);

          if (dist <= b2[2])
            adj[j].Add(i);
        }
      }

      var bs = new int[bombs.Length];

      for (var i = 0; i < bombs.Length; i++)
      {
        var queue = new Queue<int>();
        var visited = new int[bombs.Length];

        queue.Enqueue(i);
        bs[i]++;
        visited[i] = 1;

        while (queue.Count > 0)
        {
          var el = queue.Dequeue();

          foreach (var e in adj[el])
          {
            if (visited[e] == 1)
              continue;

            queue.Enqueue(e);
            bs[i]++;
            visited[e] = 1;
          }
        }
      }

      return bs.Max();
    }
  }
}
