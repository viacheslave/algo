package binarysearch;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedList;

/*
 * Problem: https://binarysearch.com/problems/Connected-Cities
 * Submission: https://binarysearch.com/problems/Connected-Cities/submissions/7265431
 */
public class P0087 {
  class Solution {
    public boolean solve(int n, int[][] roads) {
      // Kosaraju

      var adj = new HashMap<Integer, ArrayList<Integer>>();

      for (var r : roads) {
        adj.putIfAbsent(r[0], new ArrayList<>());
        adj.get(r[0]).add(r[1]);
      }

      var stack = new LinkedList<Integer>();
      var visited = new int[n];

      // forward dfs
      for (int i = 0; i < n; i++) {
        if (visited[i] == 1)
          continue;

        forwardDfs(i, stack, visited, adj);
      }

      var adjReversed = new HashMap<Integer, ArrayList<Integer>>();

      for (var r : roads) {
        adjReversed.putIfAbsent(r[1], new ArrayList<>());
        adjReversed.get(r[1]).add(r[0]);
      }

      // backwards dfs
      var set = new HashSet<Integer>();

      while (!stack.isEmpty()) {
        var u = stack.pop();

        if (set.contains(u))
          continue;;

        backwardsDfs(u, set, adjReversed);

        if (set.size() != n)
          return false;
      }

      return true;
    }

    private void forwardDfs(int u, LinkedList<Integer> stack, int[] visited, HashMap<Integer, ArrayList<Integer>> adj) {
      visited[u] = 1;

      if (adj.get(u) == null) {
        stack.push(u);
        return;
      }

      for (var v : adj.get(u)) {
        if (visited[v] == 1)
          continue;

        forwardDfs(v, stack, visited, adj);
      }

      stack.push(u);
    }

    private void backwardsDfs(Integer u, HashSet<Integer> set, HashMap<Integer, ArrayList<Integer>> adj) {
      set.add(u);

      if (adj.get(u) == null)
        return;

      for (var v : adj.get(u)) {
        if (set.contains(v))
          continue;

        backwardsDfs(v, set, adj);
      }
    }
  }
}