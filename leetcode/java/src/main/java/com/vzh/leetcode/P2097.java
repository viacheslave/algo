
package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/valid-arrangement-of-pairs/
 * Submission: https://leetcode.com/submissions/detail/597464694/
 */
public class P2097 {
  class Solution {
    public int[][] validArrangement(int[][] pairs) {
      // get adj list
      var adjList = getAdjList(pairs);

      // set up ins and outs
      var in = new HashMap<Integer, Integer>();
      var out = new HashMap<Integer, Integer>();

      for (var pair: pairs) {
        in.putIfAbsent(pair[1], 0);
        out.putIfAbsent(pair[0], 0);

        in.put(pair[1], in.get(pair[1]) + 1);
        out.put(pair[0], out.get(pair[0]) + 1);
      }

      var startNode = findStartNode(out, in);

      // euclidian path, dfs
      var path = new ArrayList<Integer>();
      dfs(startNode, out, adjList, path, new HashSet<>());

      Collections.reverse(path);

      var ans = new ArrayList<int[]>();
      for (var i = 1; i < path.size(); i++) {
        ans.add(new int[] { path.get(i - 1), path.get(i) });
      }

      return ans.toArray(int[][]::new);
    }

    private HashMap<Integer, List<Integer>> getAdjList(int[][] pairs) {
      var list = new HashMap<Integer, List<Integer>>();

      for (var pair : pairs) {
        list.putIfAbsent(pair[0], new ArrayList<>());
        list.get(pair[0]).add(pair[1]);
      }

      return list;
    }

    private int findStartNode(Map<Integer, Integer> out, Map<Integer, Integer> in) {
      var start = 0;

      for (var e : out.entrySet()) {
        if (e.getValue() - in.getOrDefault(e.getKey(), 0) == 1)
          return e.getKey();

        if (e.getValue() > 0)
          start = e.getKey();
      }

      return start;
    }

    private void dfs(int at, HashMap<Integer, Integer> out, HashMap<Integer, List<Integer>> adjList, List<Integer> path, HashSet<Integer> visited) {
      while (out.containsKey(at) && out.get(at) != 0) {
        out.put(at, out.get(at) - 1);

        var next = adjList.get(at).get(out.get(at));
        dfs(next, out, adjList, path, visited);
      }

      path.add(at);
    }
  }
}