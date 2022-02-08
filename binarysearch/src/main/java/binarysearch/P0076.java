package binarysearch;

import binarysearch.templates.Tree;

/*
 * Problem: https://binarysearch.com/problems/Merging-Binary-Trees
 * Submission: https://binarysearch.com/problems/Merging-Binary-Trees/submissions/7498497
 */
public class P0076 {
  class Solution {
    public Tree solve(Tree node0, Tree node1) {
      return merge(node0, node1);
    }

    private Tree merge(Tree node0, Tree node1) {
      if (node0 == null && node1 == null)
        return null;

      var node = new Tree();
      node.val = (node0 != null && node1 != null)
        ? node0.val + node1.val
        : (node0 == null) ? node1.val : node0.val;

      node.left = merge(node0 == null ? null : node0.left, node1 == null ? null : node1.left);
      node.right = merge(node0 == null ? null : node0.right, node1 == null ? null : node1.right);
      return node;
    }
  }
}