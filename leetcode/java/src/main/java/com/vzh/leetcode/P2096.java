
package com.vzh.leetcode;

import com.vzh.leetcode.helpers.TreeNode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/step-by-step-directions-from-a-binary-tree-node-to-another/
 * Submission: https://leetcode.com/submissions/detail/597438143/
 */
public class P2096 {
  class Solution {
    public String getDirections(TreeNode root, int startValue, int destValue) {
      var adjList = new HashMap<Integer, List<Integer>>();
      var directions = new HashMap<Pair, Character>();

      // get adj list, dfs the tree
      traverse(root, adjList, directions);

      // bfs
      var ans = bfs(adjList, directions, startValue, destValue);
      return ans;
    }

    private void traverse(TreeNode node, HashMap<Integer, List<Integer>> adjList, HashMap<Pair, Character> directions) {

      if (node.left != null) {
        adjList.putIfAbsent(node.val, new ArrayList<>());
        adjList.putIfAbsent(node.left.val, new ArrayList<>());
        adjList.get(node.val).add(node.left.val);
        adjList.get(node.left.val).add(node.val);

        directions.put(new Pair(node.val, node.left.val), 'L');
        directions.put(new Pair(node.left.val, node.val), 'U');

        traverse(node.left, adjList, directions);
      }

      if (node.right != null) {
        adjList.putIfAbsent(node.val, new ArrayList<>());
        adjList.putIfAbsent(node.right.val, new ArrayList<>());
        adjList.get(node.val).add(node.right.val);
        adjList.get(node.right.val).add(node.val);

        directions.put(new Pair(node.val, node.right.val), 'R');
        directions.put(new Pair(node.right.val, node.val), 'U');

        traverse(node.right, adjList, directions);
      }
    }

    private String bfs(HashMap<Integer, List<Integer>> adjList, HashMap<Pair, Character> directions, int startValue, int destValue) {
      var visited = new HashSet<Integer>();
      var queue = new LinkedList<Integer>();
      queue.add(startValue);

      var prev = new HashMap<Integer, Integer>();

      while (!queue.isEmpty()) {
        var el = queue.poll();
        if (el == destValue)
          break;

        for (var n : adjList.get(el)) {
          if (!visited.contains(n)) {
            queue.add(n);
            prev.put(n, el);
            visited.add(n);
          }
        }
      }

      var path = new StringBuilder();
      for (var current = destValue; current != startValue; current = prev.get(current)) {
        path.append(directions.get(new Pair(prev.get(current), current)));
      }

      return path.reverse().toString();
    }

    public class Pair {
      public int from;
      public int to;

      public Pair(int from, int to) {
        this.from = from;
        this.to = to;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Pair pair = (Pair) o;
        return from == pair.from && to == pair.to;
      }

      @Override
      public int hashCode() {
        return Objects.hash(from, to);
      }
    }
  }
}