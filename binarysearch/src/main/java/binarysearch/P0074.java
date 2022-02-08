package binarysearch;

import binarysearch.templates.Tree;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Search-in-a-Binary-Search-Tree
 * Submission: https://binarysearch.com/problems/Search-in-a-Binary-Search-Tree/submissions/7496121
 */
public class P0074 {
  class Solution {
    public boolean solve(Tree root, int val) {
      return search(root, val);
    }

    private boolean search(Tree node, int val) {
      if (node == null)
        return false;

      if (node.val == val)
        return true;

      if (val < node.val)
        return search(node.left, val);
      else
        return search(node.right, val);
    }
  }
}