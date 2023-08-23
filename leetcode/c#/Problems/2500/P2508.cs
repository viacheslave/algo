namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/add-edges-to-make-degrees-of-all-nodes-even/
///    Submission: https://leetcode.com/problems/add-edges-to-make-degrees-of-all-nodes-even/submissions/862026203/
/// </summary>
internal class P2508
{
  public class Solution
  {
    public bool IsPossible(int n, IList<IList<int>> edges)
    {
      var eCount = new Dictionary<int, int>();
      var eTuples = new HashSet<(int, int)>();

      for (int i = 1; i <= n; i++)
      {
        eCount[i] = 0;
      }

      foreach (var e in edges)
      {
        eCount[e[0]]++;
        eCount[e[1]]++;

        eTuples.Add((e[0], e[1]));
        eTuples.Add((e[1], e[0]));
      }

      var oddCount = eCount.Count(f => f.Value % 2 == 1);

      if (oddCount == 0)
      {
        return true;
      }

      var odd = eCount
        .Where(f => f.Value % 2 == 1)
        .Select(d => d.Key).ToArray();

      if (oddCount == 2)
      {
        var directEdge = !eTuples.Contains((odd[0], odd[1]));
        if (directEdge)
        {
          return true;
        }

        // we have another free edge
        // try link thru other nodes

        for (var i = 1; i <= n; i++)
        {
          if (i == odd[0] || i == odd[1])
            continue;

          if (EdgeOn((odd[0], i), (odd[1], i), eTuples))
          {
            return true;
          }
        }

        return false;
      }

      if (oddCount == 4)
      {
        return
          EdgeOn((odd[0], odd[1]), (odd[2], odd[3]), eTuples) ||
          EdgeOn((odd[0], odd[2]), (odd[1], odd[3]), eTuples) ||
          EdgeOn((odd[0], odd[3]), (odd[1], odd[2]), eTuples);
      }

      return false;
    }

    private bool EdgeOn((int, int) t1, (int, int) t2, HashSet<(int, int)> eTuples)
    {
      return !eTuples.Contains(t1) && !eTuples.Contains(t2);
    }
  }
}
