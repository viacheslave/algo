package binarysearch;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

/*
 * Problem: https://binarysearch.com/problems/Connect-Cartesian-Coordinates
 * Submission: https://binarysearch.com/problems/Connect-Cartesian-Coordinates/submissions/7582414
 */
public class P0883 {
  class Solution {
    public int solve(int[][] points) {
      var edges = new ArrayList<Edge>();

      for (int i = 0; i < points.length; i++) {
        for (int j = i + 1; j < points.length; j++) {
          var edge = new Edge(i, j,
            Math.abs(points[i][0] - points[j][0])
              + Math.abs(points[i][1] - points[j][1]));

          edges.add(edge);
        }
      }

      Collections.sort(edges, Comparator.comparingInt(x -> x.distance));

      var ans = 0;

      // kruskal's MST
      var uf = new UnionFind(points.length);

      for (var e: edges) {
        var p1 = uf.find(e.p1);
        var p2 = uf.find(e.p2);

        if (p1 != p2) {
          uf.union(e.p1, e.p2);
          ans += e.distance;
        }
      }

      return ans;
    }

    private static class Edge {
      public int p1;
      public int p2;
      public int distance;

      public Edge(int p1, int p2, int distance) {
        this.p1 = p1;
        this.p2 = p2;
        this.distance = distance;
      }
    }

    private class UnionFind {
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

  }
}