package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Level-Order-Traversal
 * Submission: https://binarysearch.com/problems/Level-Order-Traversal/submissions/6943078
 */
public class P0070 {
  class Solution {
    public int[] solve(Tree root) {
      if (root == null)
        return null;

      var arr = new ArrayList<ArrayList<Integer>>();
      traverse(root, arr, 0);

      return arr.stream()
        .flatMapToInt(x -> x.stream().mapToInt(s -> s))
        .toArray();
    }

    private void traverse(Tree node, ArrayList<ArrayList<Integer>> arr, int level) {
      if (node == null)
        return;

      if (level >= arr.size())
        arr.add(new ArrayList<>());

      arr.get(level).add(node.val);

      traverse(node.left, arr, level + 1);
      traverse(node.right, arr, level + 1);
    }
  }

  public class Tree {
    int val;
    Tree left;
    Tree right;
  }
}