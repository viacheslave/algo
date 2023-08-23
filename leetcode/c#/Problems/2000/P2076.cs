namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/process-restricted-friend-requests/
///    Submission: https://leetcode.com/submissions/detail/587095118/
/// </summary>
internal class P2076
{
  public class Solution
  {
    public bool[] FriendRequests(int n, int[][] restrictions, int[][] requests)
    {
      var ans = new List<bool>();
      var uf = new UnionFind(n);

      foreach (var request in requests)
      {
        var p1 = uf.Find(request[0]);
        var p2 = uf.Find(request[1]);

        if (p1 == p2)
        {
          // already connected
          ans.Add(true);
          continue;
        }

        var allowed = true;

        // iterate through restrictions
        // if restriction is pair-wise equal to request, the connection cannot be allowed
        foreach (var restriction in restrictions)
        {
          var r1 = uf.Find(restriction[0]);
          var r2 = uf.Find(restriction[1]);

          if ((r1 == p1 && r2 == p2) || (r1 == p2 && r2 == p1))
          {
            allowed = false;
            break;
          }
        }

        if (allowed)
        {
          uf.Union(p1, p2);
          ans.Add(true);
        }
        else
        {
          ans.Add(false);
        }
      }

      return ans.ToArray();
    }

    private class UnionFind
    {
      private readonly int[] _parent;
      private readonly int[] _rank;

      public UnionFind(int n)
      {
        _parent = new int[n];
        _rank = new int[n];

        for (int i = 0; i < n; i++)
        {
          _parent[i] = i;
          _rank[i] = 0;
        }
      }

      public int Find(int p)
      {
        while (p != _parent[p])
        {
          _parent[p] = _parent[_parent[p]];
          p = _parent[p];
        }

        return p;
      }

      public void Union(int p, int q)
      {
        int rootP = Find(p);
        int rootQ = Find(q);

        if (rootP == rootQ)
          return;

        if (_rank[rootP] < _rank[rootQ])
        {
          _parent[rootP] = rootQ;
        }
        else if (_rank[rootP] > _rank[rootQ])
        {
          _parent[rootQ] = rootP;
        }
        else
        {
          _parent[rootQ] = rootP;
          _rank[rootP]++;
        }
      }
    }
  }
}
