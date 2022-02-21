package dsa;

public class UnionFind {
  private final int[] parent;
  private final int[] rank;

  public UnionFind(int n) {
    parent = new int[n];
    rank = new int[n];

    for (int i = 0; i < n; i++) {
      parent[i] = i;
      rank[i] = 0;
    }
  }

  public int find(int p) {
    while (p != parent[p]) {
      parent[p] = parent[parent[p]];
      p = parent[p];
    }

    return p;
  }

  public void union(int p, int q) {
    int rootP = find(p);
    int rootQ = find(q);

    if (rootP == rootQ)
      return;

    if (rank[rootP] < rank[rootQ]) {
      parent[rootP] = rootQ;
    }
    else if (rank[rootP] > rank[rootQ]) {
      parent[rootQ] = rootP;
    }
    else {
      parent[rootQ] = rootP;
      rank[rootP]++;
    }
  }
}
