namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-if-path-exists-in-graph/
///    Submission: https://leetcode.com/submissions/detail/586719131/
/// </summary>
internal class P1971
{
  public class Solution
  {
    public bool ValidPath(int n, int[][] edges, int start, int end)
    {
      // union-find
      var sets = Enumerable.Range(0, n)
        .Select(p => (value: p, rank: 0))
        .ToList();

      foreach (var edge in edges)
        Union(sets, edge[0], edge[1]);

      var startComponent = Find(sets, start);
      var endComponent = Find(sets, end);

      return startComponent == endComponent;
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

    private int Find(List<(int value, int rank)> sets, int p1)
    {
      if (sets[p1].value != p1)
      {
        var value = Find(sets, sets[p1].value);
        sets[p1] = (value, sets[p1].rank);
      }

      return sets[p1].value;
    }
  }
}
