
package binarysearch;

import binarysearch.templates.Tree;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Left-Side-View-of-a-Tree
 * Submission: https://binarysearch.com/problems/Left-Side-View-of-a-Tree/submissions/7315042
 */
public class P0175 {
  class Solution {
    public int[] solve(Tree root) {
      var arr = new ArrayList<Stack<Integer>>();

      // recursive traverse
      traverse(root, arr, 0);

      var ans = new int[arr.size()];
      for (int i = 0; i < arr.size(); i++) {
        ans[i] = arr.get(i).pop();
      }

      return ans;
    }

    private void traverse(Tree node, ArrayList<Stack<Integer>> arr, int level) {
      if (node == null)
        return;

      if (arr.size() == level) {
        arr.add(new Stack<>());
      }

      var stack = arr.get(level);
      stack.add(node.val);

      traverse(node.right, arr, level + 1);
      traverse(node.left, arr, level + 1);
    }
  }
}