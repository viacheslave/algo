package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Sum-Tree
 * Submission: https://binarysearch.com/problems/Sum-Tree/submissions/6910142
 */
public class P0181 {
  class Solution {
    public boolean solve(Tree root) {
      var arr = new ArrayList<Boolean>();
      traverse(root, arr);

      return arr.stream().allMatch(x -> x == true);
    }

    private int traverse(Tree node, ArrayList<Boolean> arr) {
      if (node == null)
        return 0;

      var sum = traverse(node.left, arr) + traverse(node.right, arr);
      if (node.left == null && node.right == null)
        return node.val;

      if (sum == node.val)
        arr.add(true);
      else arr.add(false);

      return node.val;
    }

    public class Tree {
      int val;
      Tree left;
      Tree right;
    }
  }
}