package binarysearch;

import java.util.ArrayList;
import java.util.Comparator;

/*
 * Problem: https://binarysearch.com/problems/Invert-Tree
 * Submission: https://binarysearch.com/problems/Invert-Tree/submissions/6924561
 */
public class P0072 {
  class Solution {
    public Tree solve(Tree root) {
      if (root == null)
        return null;

      traverse(root);
      return root;
    }

    private void traverse(Tree node) {
      if (node == null)
        return;

      var tmp = node.right;
      node.right = node.left;
      node.left = tmp;

      traverse(node.left);
      traverse(node.right);
    }

    public class Tree {
      int val;
      Tree left;
      Tree right;
    }
  }
}