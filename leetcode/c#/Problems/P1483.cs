namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/kth-ancestor-of-a-tree-node/
///    Submission: https://leetcode.com/submissions/detail/426034676/
/// </summary>
internal class P1483
{
  public class TreeAncestor
  {
    public class Vert
    {
      public List<Vert> Children { get; } = new List<Vert>();
      public int Value { get; }

      public Vert(int value)
      {
        Value = value;
      }

      public override string ToString() => Value.ToString();
    }

    private Vert[] _nodes;
    private Vert _root;

    private SortedDictionary<int, int[]> _sparse = new SortedDictionary<int, int[]>();

    public TreeAncestor(int n, int[] parent)
    {
      _nodes = new Vert[n];

      for (var i = 0; i < parent.Length; i++)
      {
        var vert = new Vert(i);
        _nodes[i] = vert;

        if (parent[i] == -1)
          _root = vert;
        else
          _nodes[parent[i]].Children.Add(vert);
      }

      Traverse(_root, new List<int>());
    }

    // build sparse table of parents in DFS
    private void Traverse(Vert node, List<int> list)
    {
      if (node == null)
        return;

      list.Add(node.Value);

      var level = 0;
      while ((1 << level) < list.Count)
      {
        var dist = 1 << level;
        var parent = list[list.Count - dist - 1];

        if (!_sparse.ContainsKey(dist)) _sparse[dist] = Enumerable.Repeat(-1, _nodes.Length).ToArray();
        _sparse[dist][node.Value] = parent;

        level++;
      }

      foreach (var child in node.Children)
        Traverse(child, list);

      list.RemoveAt(list.Count - 1);
    }

    public int GetKthAncestor(int node, int k)
    {
      var powers = new List<int>();
      var pow = 0;

      // get rows
      while ((1 << pow) <= k)
      {
        if ((k & (1 << pow)) == (1 << pow))
          powers.Add((1 << pow));
        pow++;
      }

      // recursively get parents
      for (var i = powers.Count - 1; i >= 0; i--)
      {
        var key = powers[i];
        if (!_sparse.ContainsKey(key))
          return -1;

        node = _sparse[key][node];

        if (node == -1)
          return -1;
      }

      return node;
    }
  }
}
