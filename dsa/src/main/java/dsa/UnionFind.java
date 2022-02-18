package dsa;

public class UnionFind {
  private final int[] _parent;
  private final int[] _rank;

  public UnionFind(int n) {
    _parent = new int[n];
    _rank = new int[n];

    for (int i = 0; i < n; i++) {
      _parent[i] = i;
      _rank[i] = 0;
    }
  }

  public int find(int p) {
    while (p != _parent[p]) {
      _parent[p] = _parent[_parent[p]];
      p = _parent[p];
    }

    return p;
  }

  public void union(int p, int q) {
    int rootP = find(p);
    int rootQ = find(q);

    if (rootP == rootQ)
      return;

    if (_rank[rootP] < _rank[rootQ]) {
      _parent[rootP] = rootQ;
    }
    else if (_rank[rootP] > _rank[rootQ]) {
      _parent[rootQ] = rootP;
    }
    else {
      _parent[rootQ] = rootP;
      _rank[rootP]++;
    }
  }
}
