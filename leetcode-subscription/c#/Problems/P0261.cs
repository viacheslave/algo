using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/graph-valid-tree/
  ///    Submission: https://leetcode.com/submissions/detail/455533199/
  ///    Microsoft, Amazon
  /// </summary>
  internal class P0261
  {
    public class Solution
    {
      public bool ValidTree(int n, int[][] edges)
      {
        if (edges.Length == 0 && n == 1)
          return true;

        if (edges.Length == 0)
          return false;

        var sete = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
          if (!sete.ContainsKey(edge[0])) sete[edge[0]] = new List<int>();
          if (!sete.ContainsKey(edge[1])) sete[edge[1]] = new List<int>();

          sete[edge[0]].Add(edge[1]);
          sete[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();
        var start = edges[0][0];

        var q = new Queue<int>();
        q.Enqueue(start);

        while (q.Count > 0)
        {
          var el = q.Dequeue();
          if (visited.Contains(el))
            return false;

          visited.Add(el);

          var dirs = sete[el].ToList();

          foreach (var next in dirs)
          {
            sete[el].Remove(next);
            sete[next].Remove(el);

            q.Enqueue(next);
          }
        }

        if (visited.Count != n)
          return false;

        return true;
      }
    }
  }
}
