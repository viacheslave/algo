package binarysearch;

import binarysearch.templates.Tree;

/*
 * Problem: https://binarysearch.com/problems/Subtree
 * Submission: https://binarysearch.com/problems/Subtree/submissions/7384161
 */
public class P0446 {
  class Solution {
    public boolean solve(Tree root, Tree target) {
      return check(root, target);
    }

    private boolean check(Tree node, Tree target) {
      if (node == null)
        return false;

      return isIdentical(node, target) ||
        check(node.left, target) ||
        check(node.right, target);
    }

    private boolean isIdentical(Tree node, Tree target) {
      if (node == null && target == null)
        return true;

      if (node == null || target == null)
        return false;

      return node.val == target.val
        && isIdentical(node.left, target.left)
        && isIdentical(node.right, target.right);
    }
  }
}