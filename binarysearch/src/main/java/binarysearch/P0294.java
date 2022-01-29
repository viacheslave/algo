package binarysearch;

import binarysearch.templates.Tree;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Partition-Tree
 * Submission: https://binarysearch.com/problems/Partition-Tree/submissions/7412288
 */
public class P0294 {
  class Solution {
    public int[] solve(Tree root) {
      if (root == null)
        return new int[] {0, 0};

      var leaves = 0;
      var nonLeaves = 0;

      var stack = new Stack<Tree>();

      stack.push(root);
      while (!stack.empty()) {
        var node = stack.pop();

        if (node.left == null && node.right == null)
          leaves++;
        else
          nonLeaves++;

        if (node.left != null)
          stack.push(node.left);

        if (node.right != null)
          stack.push(node.right);
      }

      return new int[] {leaves, nonLeaves};
    }
  }
}