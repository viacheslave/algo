package binarysearch;

import binarysearch.templates.Tree;

import java.util.TreeMap;

/*
 * Problem: https://binarysearch.com/problems/Tree-Sum
 * Submission: https://binarysearch.com/problems/Tree-Sum/submissions/7606981
 */
public class P0063 {
  class Solution {
    public int solve(Tree root) {
      return dfs(root);
    }

    private int dfs(Tree node) {
      if (node == null)
        return 0;

      return dfs(node.left) + dfs(node.right) + node.val;
    }
  }
}