package binarysearch;

import binarysearch.templates.Tree;

/*
 * Problem: https://binarysearch.com/problems/Enlarge-BST
 * Submission: https://binarysearch.com/problems/Enlarge-BST/submissions/7623428
 */
public class P0864 {
  class Solution {
    public Tree solve(Tree root) {
      dfs(root, 0);
      return root;
    }

    private int dfs(Tree node, int current) {
      if (node == null)
        return current;

      current = dfs(node.right, current);

      current += node.val;
      node.val = current;

      current = dfs(node.left, current);

      return current;
    }
  }
}