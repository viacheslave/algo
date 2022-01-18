package binarysearch;

import java.util.*;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Friend-Groups
 * Submission: https://binarysearch.com/problems/Friend-Groups/submissions/7309637
 */
public class P0150 {
  class Solution {
    public int solve(int[][] friends) {
      var adj = new HashMap<Integer, List<Integer>>();

      for (int i = 0; i < friends.length; i++) {
        adj.put(i, Arrays.stream(friends[i]).boxed().collect(Collectors.toList()));
      }

      var ans = 0;
      var visited = new HashSet<Integer>();

      // dfs
      for (var k : adj.keySet()) {
        if (visited.contains(k))
          continue;

        dfs(adj, k, visited);
        ans++;
      }

      return ans;
    }

    private void dfs(HashMap<Integer, List<Integer>> adj, Integer k, HashSet<Integer> visited) {
      if (visited.contains(k))
        return;

      visited.add(k);

      for (var e : adj.get(k)) {
        dfs(adj, e, visited);
      }
    }
  }
}