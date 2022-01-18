package binarysearch;

import java.util.ArrayList;
import java.util.List;
import java.util.TreeMap;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Shipping-and-Receiving
 * Submission: https://binarysearch.com/problems/Shipping-and-Receiving/submissions/7304958
 */
public class P0402 {
  class Solution {
    public int solve(int[][] ports, int[][] shipments) {
      var n = ports.length;
      var dist = new int[n][n];

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
          dist[i][j] = Integer.MAX_VALUE;
        }
        dist[i][i] = 0;
      }

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < ports[i].length; j++) {
          var p = ports[i][j];
          dist[i][p] = 1;
        }
      }

      // floyd warshall
      // O(n3)

      for (int k = 0; k < n; k++) {
        for (int i = 0; i < n; i++) {
          for (int j = 0; j < n; j++) {
            if (dist[i][k] != Integer.MAX_VALUE && dist[k][j] != Integer.MAX_VALUE
              && dist[i][k] + dist[k][j] < dist[i][j]) {
              dist[i][j] = dist[i][k] + dist[k][j];
            }
          }
        }
      }

      var ans = 0;
      for (var s : shipments) {
        ans += dist[s[0]][s[1]] == Integer.MAX_VALUE ? 0 : dist[s[0]][s[1]];
      }

      return ans;
    }
  }
}