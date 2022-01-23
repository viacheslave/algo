package binarysearch;

import binarysearch.templates.Tree;

import java.util.ArrayList;
import java.util.Comparator;

/*
 * Problem: https://binarysearch.com/problems/Subtree-with-Maximum-Average
 * Submission: https://binarysearch.com/problems/Subtree-with-Maximum-Average/submissions/7357115
 */
public class P0952 {
  class Solution {
    public double solve(Tree root) {
      return maxAverage(root).average;
    }

    private Average maxAverage(Tree node) {
      if (node == null) {
        return new Average(0, 0,0);
      }

      var left = maxAverage(node.left);
      var right = maxAverage(node.right);

      var average = Math.max(
        Math.max(left.average, right.average),
        (left.sum + right.sum + node.val) * 1d / (left.count + right.count + 1));

      return new Average(average, left.count + right.count + 1, left.sum + right.sum + node.val);
    }

    private static class Average {
      public double average;
      public int count;
      public int sum;

      public Average(double average, int count, int sum) {
        this.average = average;
        this.count = count;
        this.sum = sum;
      }
    }
  }
}