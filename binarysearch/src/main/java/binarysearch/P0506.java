package binarysearch;

import binarysearch.templates.Tree;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Only-Child
 * Submission: https://binarysearch.com/problems/Only-Child/submissions/7430740
 */
public class P0506 {
  class Solution {
    public int solve(Tree root) {
      if (root == null)
        return 0;

      var ans = 0;

      var stack = new Stack<Tree>();
      stack.push(root);

      while (!stack.empty()) {
        var node = stack.pop();

        if (node.left != null) {
          if (node.right == null) {
            ans++;
          }
          stack.push(node.left);
        }

        if (node.right != null) {
          if (node.left == null) {
            ans++;
          }
          stack.push(node.right);
        }
      }

      return ans;
    }
  }
}