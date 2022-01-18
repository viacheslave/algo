package binarysearch;

import java.util.Arrays;
import java.util.Comparator;
import java.util.Map;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Ambigram-Detection
 * Submission: https://binarysearch.com/problems/Ambigram-Detection/submissions/6666339
 */
public class P1013 {
  class Solution {
    private int[] parent;
    private int[] rank;

    public boolean solve(String s, String[][] pairs) {
      parent = new int[26];
      rank = new int[26];

      for (var i = 0; i < 26; i++) {
        parent[i] = i;
        rank[i] = 0;
      }

      for (var pair : pairs) {
        var ch0 = pair[0].charAt(0) - 97;
        var ch1 = pair[1].charAt(0) - 97;

        union(ch0, ch1);
      }

      var sb = new StringBuilder();
      for (var i = 0; i < s.length(); i++) {
        var value = find(s.charAt(i) - 97);
        sb.append((char)(97 + value));
      }

      for (var  i =0; i < sb.length(); i++) {
        if (sb.charAt(i) != sb.charAt(sb.length() - i - 1))
          return false;
      }

      return true;
    }

    public int find(int p) {
      while (p != parent[p]) {
        parent[p] = parent[parent[p]];    // path compression by halving
        p = parent[p];
      }
      return p;
    }

    public void union(int p, int q) {
      int rootP = find(p);
      int rootQ = find(q);
      if (rootP == rootQ) return;

      if      (rank[rootP] < rank[rootQ]) parent[rootP] = rootQ;
      else if (rank[rootP] > rank[rootQ]) parent[rootQ] = rootP;
      else {
        parent[rootQ] = rootP;
        rank[rootP]++;
      }
    }
  }
}