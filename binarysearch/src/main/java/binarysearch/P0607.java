package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Sum-of-Digit-Paths-in-a-Tree
 * Submission: https://binarysearch.com/problems/Sum-of-Digit-Paths-in-a-Tree/submissions/6924542
 */
public class P0607 {
  class Solution {
    public int solve(Tree root) {
      if (root == null)
        return 0;

      var max = Integer.MIN_VALUE;
      var arr = new ArrayList<Integer>();

      traverse(root, new StringBuilder(), arr);

      return arr.stream().mapToInt(x -> x).sum();
    }

    private void traverse(Tree node, StringBuilder sb, ArrayList<Integer> arr) {
      if (node == null)
        return;

      sb.append(node.val);

      traverse(node.left, sb, arr);
      traverse(node.right, sb, arr);

      if (node.left == null && node.right == null) {
        arr.add(Integer.parseInt(sb.toString()));
      }

      sb.deleteCharAt(sb.length() - 1);
    }

    public class Tree {
      int val;
      Tree left;
      Tree right;
    }
  }
}