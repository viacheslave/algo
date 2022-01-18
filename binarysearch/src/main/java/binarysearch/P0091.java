package binarysearch;

import java.util.AbstractMap;
import java.util.ArrayList;
import java.util.Map;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Inorder-Traversal
 * Submission: https://binarysearch.com/problems/Inorder-Traversal/submissions/6910730
 */
public class P0091 {
  class Solution {
    public int[] solve(Tree root) {
      var arr = new ArrayList<Integer>();
      traverse(root, arr);

      return arr.stream().mapToInt(x -> x).toArray();
    }

    private void traverse(Tree node, ArrayList<Integer> arr) {
      if (node == null)
        return;

      traverse(node.left, arr);
      arr.add(node.val);
      traverse(node.right, arr);
    }

    public class Tree {
      int val;
      Tree left;
      Tree right;
    }

  }
}