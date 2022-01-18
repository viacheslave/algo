package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/similar-string-groups/
 * Submission: https://leetcode.com/submissions/detail/591185177/
 */
public class P0839 {
  class Solution {
    public int numSimilarGroups(String[] strs) {
      var uf = new UnionFind(strs.length);

      for (int i = 0; i < strs.length - 1; i++) {
        for (int j = 1; j < strs.length; j++) {
          if (similar(strs[i], strs[j]))
            uf.Union(i, j);
        }
      }

      var set = new HashSet<Integer>();
      for (int i = 0; i < strs.length; i++) {
        set.add(uf.Find(i));
      }

      return set.size();
    }

    private boolean similar(String str1, String str2) {
      if (str1.equals(str2))
        return true;

      var arr = new ArrayList<Integer>();

      for (int i = 0; i < str1.length(); i++) {
        if (str1.charAt(i) != str2.charAt(i))
          arr.add(i);
      }

      return arr.size() == 2 &&
        str1.charAt(arr.get(0)) == str2.charAt(arr.get(1)) &&
        str1.charAt(arr.get(1)) == str2.charAt(arr.get(0));
    }

    private class UnionFind {
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

      public int Find(int p) {
        while (p != parent[p]) {
          parent[p] = parent[parent[p]];
          p = parent[p];
        }

        return p;
      }

      public void Union(int p, int q) {
        int rootP = Find(p);
        int rootQ = Find(q);

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
  }
}