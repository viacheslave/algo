package binarysearch;

import binarysearch.templates.Tree;

import java.util.LinkedList;
import java.util.Queue;

/*
 * Problem: https://binarysearch.com/problems/Binary-Search-Tree-Validation
 * Submission: https://binarysearch.com/problems/Binary-Search-Tree-Validation/submissions/7303582
 */
public class P0069 {
  class Solution {
    public boolean solve(Tree root) {
      if (root == null)
        return true;

      var result = validate(root);
      return result.valid;
    }

    private ValidationResult validate(Tree node) {
      if (node == null)
        return null;

      ValidationResult left = validate(node.left);
      ValidationResult right = validate(node.right);

      var min = node.val;
      var max = node.val;
      boolean valid = true;

      if (left != null && left.max < node.val) {
        min = left.min;
      }

      if (right != null && right.min > node.val) {
        max = right.max;
      }

      valid =
        (left == null || (left.valid && left.max < node.val)) &&
          (right == null || (right.valid && right.min > node.val));

      ValidationResult result = new ValidationResult(valid, min, max);
      return result;
    }

    private static class ValidationResult {
      public boolean valid;
      public int min;
      public int max;

      public ValidationResult(boolean valid, int min, int max) {
        this.valid = valid;
        this.min = min;
        this.max = max;
      }
    }
  }
}