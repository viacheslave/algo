package binarysearch;

import binarysearch.templates.Tree;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Longest-Even-Value-Path
 * Submission: https://binarysearch.com/problems/Longest-Even-Value-Path/submissions/7418180
 */
public class P0336 {
  class Solution {
    public int solve(Tree root) {
      var res = dfs(root);
      return res.maxSoFar;
    }

    private Result dfs(Tree node) {
      if (node == null)
        return new Result(0, 0);

      var l = dfs(node.left);
      var r = dfs(node.right);

      var maxSoFar = Math.max(l.maxSoFar, r.maxSoFar);
      if (node.val % 2 == 0) {
        maxSoFar = Math.max(maxSoFar, 1 + l.length + r.length);
      }

      var length = node.val % 2 == 0
        ? Math.max(1 + l.length, 1 + r.length)
        : 0;

      return new Result(maxSoFar, length);
    }

    private static class Result {
      public int maxSoFar;
      public int length;

      public Result(int maxSoFar, int length) {
        this.maxSoFar = maxSoFar;
        this.length = length;
      }
    }
  }
}