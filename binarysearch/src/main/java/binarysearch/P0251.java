package binarysearch;

import java.util.HashSet;
import java.util.LinkedList;

/*
 * Problem: https://binarysearch.com/problems/Univalue-Tree
 * Submission: https://binarysearch.com/problems/Univalue-Tree/submissions/6915839
 */
public class P0251 {
  class Solution {
    public boolean solve(Tree root) {
      var set = new HashSet<Integer>();
      var stack = new LinkedList<Tree>();
      stack.add(root);

      while (!stack.isEmpty()) {
        var el = stack.poll();
        set.add(el.val);

        if (el.left != null)
          stack.add(el.left);

        if (el.right != null)
          stack.add(el.right);
      }

      return set.size() == 1;
    }
  }

  public class Tree {
    int val;
    Tree left;
    Tree right;
  }
}
