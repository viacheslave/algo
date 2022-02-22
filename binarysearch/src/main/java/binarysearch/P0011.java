package binarysearch;

import binarysearch.templates.LLNode;
import binarysearch.templates.Tree;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Univalue-Tree-Count
 * Submission: https://binarysearch.com/problems/Univalue-Tree-Count/submissions/7616170
 */
public class P0011 {
  class Solution {
    public int solve(Tree root) {
      return dfs(root).count;
    }

    public Uni dfs(Tree node) {
      if (node == null) {
        return null;
      }

      var left = dfs(node.left);
      var right = dfs(node.right);

      if (left == null && right == null)
        return new Uni(1, true);

      var uni =
        (left == null || (left.uni && node.left.val == node.val)) &&
          (right == null || (right.uni && node.right.val == node.val));

      var count = (left == null ? 0 : left.count) +
        (right == null ? 0 : right.count);

      if (uni)
        count++;

      return new Uni(count, uni);
    }

    private static class Uni {
      public int count;
      public boolean uni;

      public Uni(int count, boolean uni) {
        this.count = count;
        this.uni = uni;
      }
    }
  }
}