package binarysearch;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/*
 * Problem: https://binarysearch.com/problems/Reverse-Graph
 * Submission: https://binarysearch.com/problems/Reverse-Graph/submissions/7309743
 */
public class P0223 {
  class Solution {
    public int[][] solve(int[][] graph) {
      var adj = new HashMap<Integer, List<Integer>>();

      for (int i = 0; i < graph.length; i++) {
        for (int j = 0; j < graph[i].length; j++) {
          adj.putIfAbsent(graph[i][j], new ArrayList<>());
          adj.get(graph[i][j]).add(i);
        }
      }

      var ans = new int[graph.length][];

      for (int i = 0; i < graph.length; i++) {
        var values = adj.getOrDefault(i, new ArrayList<>());
        ans[i] = values.stream().mapToInt(x -> x).toArray();
      }

      return ans;
    }
  }
}