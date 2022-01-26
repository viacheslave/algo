package binarysearch;

import binarysearch.templates.Tree;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Sum-of-Two-Numbers-in-BSTs
 * Submission: https://binarysearch.com/problems/Sum-of-Two-Numbers-in-BSTs/submissions/7380332
 */
public class P0858 {
  class Solution {
    public boolean solve(Tree a, Tree b, int target) {
      Stack<Tree> aNodes = new Stack<>();

      aNodes.push(a);
      while (!aNodes.empty()) {
        var node = aNodes.pop();
        if (node.left != null)
          aNodes.push(node.left);

        if (node.right != null)
          aNodes.push(node.right);

        boolean res = binarySearch(b, target - node.val);
        if (res) {
          return true;
        }
      }
      return false;
    }

    private boolean binarySearch(Tree b, int target) {
      if (b == null)
        return false;

      if (b.val == target)
        return true;

      if (b.val > target)
        return binarySearch(b.left, target);

      return binarySearch(b.right, target);
    }
  }
}