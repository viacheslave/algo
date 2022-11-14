namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/most-profitable-path-in-a-tree/ 
///    Submission: https://leetcode.com/problems/most-profitable-path-in-a-tree/submissions/842752396/
/// </summary>
internal class P2467
{
  public class Solution
  {
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
      // build adj list
      var adj = new Dictionary<int, List<int>>();

      foreach (var edge in edges)
      {
        if (!adj.ContainsKey(edge[0])) adj[edge[0]] = new List<int>();
        if (!adj.ContainsKey(edge[1])) adj[edge[1]] = new List<int>();

        adj[edge[0]].Add(edge[1]);
        adj[edge[1]].Add(edge[0]);
      }

      // get Bob's path
      List<int> bobPath = new();
      Stack<int> currentPath = new();
      currentPath.Push(bob);

      BobDFS(adj, bob, -1, currentPath, bobPath);

      // DFS into Alice path
      List<int> leafs = new();
      int currentScore = 0;
      HashSet<int> bobTaken = new HashSet<int>();

      AliceDFS(adj, 0, -1, currentScore, bobPath, bobTaken, 0, leafs, amount);

      return leafs.Max();
    }

    private void AliceDFS(Dictionary<int, List<int>> adj, int current, int previous, int currentScore,
      List<int> bobPath, HashSet<int> bobTaken, int step,
      List<int> leafs,
      int[] amount)
    {
      var alicePoint = current;
      var bobPoint = step >= bobPath.Count ? -1 : bobPath[step];

      if (alicePoint == bobPoint)
      {
        currentScore += amount[alicePoint] / 2;
      }
      else if (bobTaken.Contains(alicePoint))
      {
        currentScore += 0;
      }
      else
      {
        currentScore += amount[alicePoint];
      }

      bobTaken.Add(bobPoint);

      if (adj[current].Count == 1 && current != 0)
      {
        // leaf
        leafs.Add(currentScore);
      }
      else
      {
        foreach (var item in adj[current])
        {
          if (item == previous)
            continue;

          AliceDFS(adj, item, current, currentScore, bobPath, bobTaken, step + 1, leafs, amount);
        }
      }

      bobTaken.Remove(bobPoint);
    }

    private void BobDFS(Dictionary<int, List<int>> adj, int current, int previous, Stack<int> currentPath, List<int> bobPath)
    {
      foreach (var item in adj[current])
      {
        if (item == previous)
          continue;

        currentPath.Push(item);

        if (item == 0)
        {
          bobPath.AddRange(currentPath.Reverse());
          break;
        }

        BobDFS(adj, item, current, currentPath, bobPath);

        currentPath.Pop();
      }
    }
  }

}
