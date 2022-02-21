package binarysearch;

import binarysearch.templates.Tree;

import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;

/*
 * Problem: https://binarysearch.com/problems/Most-Frequent-Subtree-Sum
 * Submission: https://binarysearch.com/problems/Most-Frequent-Subtree-Sum/submissions/7606136
 */
public class P0083 {
  class Solution {
    public int solve(Tree root) {
      var map = new HashMap<Integer, Integer>();
      dfs(root, map);

      return map.entrySet().stream()
        .max(Comparator.comparingInt(Map.Entry::getValue)).get().getKey();
    }

    private int dfs(Tree root, HashMap<Integer, Integer> map) {
      if (root == null)
        return 0;

      var left = dfs(root.left, map);
      var right = dfs(root.right, map);

      var sum = root.val + left + right;

      map.put(sum, map.getOrDefault(sum, 0) + 1);
      return sum;
    }
  }
}