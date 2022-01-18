package binarysearch;

import java.util.ArrayList;
import java.util.List;
import java.util.TreeMap;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Sum-of-the-Deepest-Nodes
 * Submission: https://binarysearch.com/problems/Sum-of-the-Deepest-Nodes/submissions/6909977
 */
public class P0065 {
  class Solution {
    public int solve(Tree root) {
      if (root == null)
        return 0;

      var map = new TreeMap<Integer, List<Integer>>();
      traverse(root, 0, map);

      return map.lastEntry().getValue().stream().collect(Collectors.summingInt(x -> x));
    }

    private void traverse(Tree node, int level, TreeMap<Integer, List<Integer>> map) {
      if (node == null)
        return;

      map.putIfAbsent(level, new ArrayList<>());
      map.get(level).add(node.val);

      traverse(node.left, level + 1, map);
      traverse(node.right, level + 1, map);
    }

    public class Tree {
      int val;
      Tree left;
      Tree right;
    }
  }
}