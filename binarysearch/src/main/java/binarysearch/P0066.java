package binarysearch;

import binarysearch.templates.*;

/*
 * Problem: https://binarysearch.com/problems/Twin-Trees
 * Submission: https://binarysearch.com/problems/Twin-Trees/submissions/7314945
 */
public class P0066 {
  class Solution {
    public boolean solve(Tree root0, Tree root1) {
      return equal(root0, root1);
    }

    private boolean equal(Tree root0, Tree root1) {
      if (root0 == null && root1 == null)
        return true;

      if (root0 != null && root1 != null) {
        return
          equal(root0.left, root1.left) &&
            equal(root0.right, root1.right) &&
            root0.val == root1.val;
      }

      return false;
    }
  }
}