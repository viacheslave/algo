namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-all-people-with-secret/
///    Submission: https://leetcode.com/submissions/detail/725111848/
/// </summary>
internal class P2092
{
  public class Solution
  {
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
      // build adj list
      var adj = new List<(int, int)>[n];

      for (int i = 0; i < n; i++)
      {
        adj[i] = new List<(int, int)>();
      }

      foreach (var meeting in meetings)
      {
        adj[meeting[0]].Add((meeting[1], meeting[2]));
        adj[meeting[1]].Add((meeting[0], meeting[2]));
      }

      // share with first person
      adj[0].Add((firstPerson, 0));

      // dfs with timing check

      var visited = new int[n];

      var pq = new PriorityQueue<(int v, int time), int>();
      pq.Enqueue((0, 0), 0);

      while (pq.Count > 0)
      {
        var (v, d) = pq.Dequeue();

        if (visited[v] == 1)
          continue;

        visited[v] = 1;

        foreach (var ad in adj[v])
        {
          var next = ad.Item1;
          var time = ad.Item2;

          if (time < d)
            continue;

          pq.Enqueue(ad, time);
        }
      }

      return visited
        .Select((v, i) => (v, i))
        .Where(c => c.v == 1)
        .Select(c => c.i)
        .ToList();
    }
  }

}
