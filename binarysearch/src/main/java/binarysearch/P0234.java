package binarysearch;

import binarysearch.templates.Tree;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;

/*
 * Problem: https://binarysearch.com/problems/Largest-Tree-Sum-Path
 * Submission: https://binarysearch.com/problems/Largest-Tree-Sum-Path/submissions/7335219
 */
public class P0234 {
  class Solution {
    public int solve(Tree root) {
      var sums = new ArrayList<Integer>();

      // recursive
      rec(root, sums);

      return sums.stream().max(Comparator.naturalOrder()).get();
    }

    private Pair rec(Tree node, ArrayList<Integer> sums) {
      if (node == null) {
        return new Pair(0, 0);
      }

      var left = rec(node.left, sums);
      var right = rec(node.right, sums);

      var maxLeft = Math.max(left.left, left.right);
      var maxRight = Math.max(right.left, right.right);

      // post-order traversal
      var value = Math.max(
        Math.max(
          node.val,
          node.val + maxLeft +  maxRight),
        Math.max(
          maxLeft + node.val,
          maxRight + node.val
        ));

      sums.add(value);
      return new Pair(maxLeft + node.val, maxRight + node.val);
    }

    private static class Pair {
      public int left;
      public int right;

      public Pair (int left, int right) {
        this.left = left;
        this.right = right;
      }
    }
  }
}