package binarysearch;

import binarysearch.templates.Tree;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Inorder-Successor
 * Submission: https://binarysearch.com/problems/Inorder-Successor/submissions/7384078
 */
public class P0440 {
  class Solution {
    public int solve(Tree root, int t) {
      var result = find(root, null, t);
      return result;
    }

    private int find(Tree node, Tree parent, int t) {
      if (node.val == t) {
        if (node.right != null) {
          var current = node.right;
          while (current.left != null) {
            current = current.left;
          }

          return current.val;
        }
        else {
          return parent.val;
        }
      }

      if (node.val < t) {
        return find(node.right, parent, t);
      }
      else {
        return find(node.left, node, t);
      }
    }
  }
}