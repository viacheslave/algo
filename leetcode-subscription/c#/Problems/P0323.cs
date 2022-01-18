using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/
  ///    Submission: https://leetcode.com/submissions/detail/455541870/
  ///    All
  /// </summary>
  internal class P0323
  {
    public class Solution
    {
      public int CountComponents(int n, int[][] edges)
      {
        var sets = Enumerable.Range(0, n)
          .Select(p => (value: p, rank: 0))
          .ToList();

        // union-find pairs
        foreach (var edge in edges)
        {
          var component1 = Find(sets, edge[0]);
          var component2 = Find(sets, edge[1]);

          if (component1 == component2)
            continue;

          Union(sets, edge[0], edge[1]);
        }

        var parents = new HashSet<int>();

        // adjust parents
        for (var i = 0; i < n; i++)
          parents.Add(Find(sets, i));

        return parents.Count;
      }

      private int Find(List<(int value, int rank)> sets, int p1)
      {
        if (sets[p1].value != p1)
        {
          var value = Find(sets, sets[p1].value);
          sets[p1] = (value, sets[p1].rank);
        }

        return sets[p1].value;
      }

      private void Union(List<(int value, int rank)> sets, int p1, int p2)
      {
        var value1 = Find(sets, p1);
        var value2 = Find(sets, p2);

        if (sets[value1].rank < sets[value2].rank)
        {
          sets[value1] = (value2, sets[value1].rank);
        }
        else if (sets[value1].rank > sets[value2].rank)
        {
          sets[value2] = (value1, sets[value2].rank);
        }
        else
        {
          sets[value1] = (value2, sets[value1].rank);
          sets[value2] = (sets[value2].value, sets[value2].rank + 1);
        }
      }
    }
  }
}
