package binarysearch;

import binarysearch.templates.Tree;

import java.util.Stack;
import java.util.TreeMap;
import java.util.TreeSet;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Second-Place
 * Submission: https://binarysearch.com/problems/Second-Place/submissions/7623530
 */
public class P0505 {
  class Solution {
    public int solve(Tree root) {
      var treeMap = new TreeMap<Integer, TreeSet<Integer>>();
      dfs(root, treeMap, 0);

      var key = treeMap.keySet().stream().collect(Collectors.toList()).get(treeMap.size() - 2);
      return key;
    }

    private void dfs(Tree node, TreeMap<Integer, TreeSet<Integer>> treeMap, int level) {
      if (node == null)
        return;

      if (node.left == null && node.right == null) {
        treeMap.putIfAbsent(level, new TreeSet<>());
        treeMap.get(level).add(node.val);
      }

      dfs(node.left, treeMap, level + 1);
      dfs(node.right, treeMap, level + 1);
    }
  }
}