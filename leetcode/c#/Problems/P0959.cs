namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/regions-cut-by-slashes/
///    Submission: https://leetcode.com/problems/regions-cut-by-slashes/submissions/868676914/
/// </summary>
internal class P0959
{
  public class Solution
  {
    public int RegionsBySlashes(string[] grid)
    {
      // union-find all areas of split

      var n = grid.Length;
      var cells = new Dictionary<(int x, int y), Cell>();

      var id = 0;

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < n; j++)
        {
          var cell = new Cell();

          if (grid[i][j] == ' ')
          {
            var c = new Triangle(id++);

            cell.left = c;
            cell.top = c;
            cell.right = c;
            cell.bottom = c;

            cell.items.Add(c);
          }

          if (grid[i][j] == '/')
          {
            var l = new Triangle(id++);
            var r = new Triangle(id++);

            cell.left = l;
            cell.top = l;
            cell.right = r;
            cell.bottom = r;

            cell.items.Add(l);
            cell.items.Add(r);
          }

          if (grid[i][j] == '\\')
          {
            var l = new Triangle(id++);
            var r = new Triangle(id++);

            cell.left = l;
            cell.bottom = l;
            cell.top = r;
            cell.right = r;

            cell.items.Add(l);
            cell.items.Add(r);
          }

          cells[(i, j)] = cell;
        }
      }

      var areas = cells.Values.SelectMany(d => d.items).ToList();

      var uf = new UnionFind(areas.Count);

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < n; j++)
        {
          var pl = (i, j - 1);
          if (Valid(pl, n))
            uf.Union(cells[(i, j)].left.id, cells[pl].right.id);

          var pr = (i, j + 1);
          if (Valid(pr, n))
            uf.Union(cells[(i, j)].right.id, cells[pr].left.id);

          var pt = (i - 1, j);
          if (Valid(pt, n))
            uf.Union(cells[(i, j)].top.id, cells[pt].bottom.id);

          var pb = (i + 1, j);
          if (Valid(pb, n))
            uf.Union(cells[(i, j)].bottom.id, cells[pb].top.id);
        }
      }

      var ans = areas.Select(d => uf.Find(d.id)).Distinct().Count();
      return ans;
    }

    private bool Valid((int, int) point, int n)
    {
      return point.Item1 >= 0 && point.Item2 >= 0 && point.Item1 < n && point.Item2 < n;
    }

    private class Cell
    {
      public Triangle left;
      public Triangle top;
      public Triangle right;
      public Triangle bottom;

      public List<Triangle> items = new List<Triangle>();
    }

    private record Triangle(int id);

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
