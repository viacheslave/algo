package binarysearch;

import java.util.ArrayList;
import java.util.Comparator;

/*
 * Problem: https://binarysearch.com/problems/Largest-Root-to-Leaf-Sum
 * Submission: https://binarysearch.com/problems/Largest-Root-to-Leaf-Sum/submissions/6924513
 */
public class P0082 {
  class Solution {
    public int solve(Tree root) {
      if (root == null)
        return 0;

      var max = Integer.MIN_VALUE;
      var arr = new ArrayList<Integer>();

      traverse(root, 0, arr);

      return arr.stream().max(Comparator.naturalOrder()).get();
    }

    private void traverse(Tree node, int sum, ArrayList<Integer> arr) {
      if (node == null)
        return;

      traverse(node.left, sum + node.val, arr);
      traverse(node.right, sum + node.val, arr);

      if (node.left == null && node.right == null)
        arr.add(sum + node.val);
    }

    public class Tree {
      int val;
      Tree left;
      Tree right;
    }
  }
}