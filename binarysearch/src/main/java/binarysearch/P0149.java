package binarysearch;

import java.util.HashSet;

/*
 * Problem: https://binarysearch.com/problems/No-New-Friends
 * Submission: https://binarysearch.com/problems/No-New-Friends/submissions/7308168
 */
public class P0149 {
  class Solution {
    public boolean solve(int n, int[][] friends) {
      var adj = new HashSet<Integer>();

      for (var e : friends) {
        adj.add(e[0]);
        adj.add(e[1]);
      }

      return adj.size() == n;
    }
  }
}