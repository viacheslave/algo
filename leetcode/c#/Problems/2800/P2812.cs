namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/find-the-safest-path-in-a-grid/
///    Submission: https://leetcode.com/problems/find-the-safest-path-in-a-grid/submissions/1020265075/
/// </summary>
internal class P2812
{
  public class Solution
  {
    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
      var n = grid.Count;
      var cellSafeness = new int[n, n];

      // bfs
      var visited = new HashSet<(int, int)>();
      var q = new Queue<(int, int, int)>();
      for (var i = 0; i < n; i++)
      {
        for (var j = 0; j < n; j++)
        {
          if (grid[i][j] == 1)
          {
            q.Enqueue((i, j, -1));
          }
        }
      }

      var directions = new List<(int, int)>
    {
      (0,1),(0,-1),(1,0),(-1,0),
    };

      while (q.Count > 0)
      {
        var item = q.Dequeue();
        if (visited.Contains((item.Item1, item.Item2)))
          continue;

        visited.Add((item.Item1, item.Item2));

        cellSafeness[item.Item1, item.Item2] = item.Item3 + 1;
        foreach (var d in directions)
        {
          var cell = (item.Item1 + d.Item1, item.Item2 + d.Item2);
          if (visited.Contains(cell))
            continue;

          if (cell.Item1 < 0 || cell.Item2 < 0 || cell.Item1 >= n || cell.Item2 >= n)
            continue;

          q.Enqueue((cell.Item1, cell.Item2, item.Item3 + 1));
        }
      }

      var max = int.MinValue;
      for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
          max = Math.Max(max, cellSafeness[i, j]);

      // check max
      if (ExistsPath(cellSafeness, max, n))
      {
        return max;
      }

      // binary search
      var left = 0;
      var right = max;

      while (left < right)
      {
        var mid = (left + right + 1) / 2;
        if (ExistsPath(cellSafeness, mid, n))
        {
          left = mid;
        }
        else
        {
          right = mid - 1;
        }
      }

      return left;
    }

    private bool ExistsPath(int[,] cellSafeness, int max, int n)
    {
      if (cellSafeness[0, 0] < max || cellSafeness[n - 1, n - 1] < max)
        return false;

      // UF
      var uf = new UnionFind(n * n);

      var directions = new List<(int, int)>
    {
      (0,1),(0,-1),(1,0),(-1,0),
    };

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < n; j++)
        {
          var b = (i, j);

          if (cellSafeness[b.i, b.j] < max)
            continue;

          foreach (var d in directions)
          {
            var c = (i: i + d.Item1, j: j + d.Item2);
            if (c.i < 0 || c.j < 0 || c.i >= n || c.j >= n)
              continue;

            if (cellSafeness[c.i, c.j] >= max)
              uf.Union(b.i * n + b.j, c.i * n + c.j);
          }
        }
      }

      return uf.Find(0) == uf.Find(n * n - 1);
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
