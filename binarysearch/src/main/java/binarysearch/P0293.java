package binarysearch;

import binarysearch.templates.Tree;

import java.util.ArrayList;
import java.util.Comparator;

/*
 * Problem: https://binarysearch.com/problems/Symmetric-Binary-Tree
 * Submission: https://binarysearch.com/problems/Symmetric-Binary-Tree/submissions/7331343
 */
public class P0293 {
  class Solution {
    public boolean solve(Tree root) {
      if (root == null)
        return true;

      return symm(root.left, root.right);
    }

    private boolean symm(Tree left, Tree right) {
      if (left == null && right == null)
        return true;

      if (left == null || right == null)
        return false;

      return left.val == right.val &&
        symm(left.left, right.right) &&
        symm(left.right, right.left);
    }
  }
}