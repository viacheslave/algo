package binarysearch;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.LinkedList;

/*
 * Problem: https://binarysearch.com/problems/Wildfire
 * Submission: https://binarysearch.com/problems/Wildfire/submissions/7304843
 */
public class P0255 {
  class Solution {
    public int solve(int[][] matrix) {

      var queue = new LinkedList<Pair>();
      var n = matrix.length;
      if (n == 0)
        return 0;

      var m = matrix[0].length;
      var ans = 0;

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
          if (matrix[i][j] == 2)
            queue.offer(new Pair(i, j, 0));
        }
      }

      var dx = new int[] {0,1,0,-1};
      var dy = new int[] {1,0,-1,0};

      while (!queue.isEmpty()) {
        var el = queue.poll();
        if (matrix[el.x][el.y] != 2)
          continue;

        ans = Math.max(ans, el.distance);

        for (int i = 0; i < 4; i++) {
          var px = el.x + dx[i];
          var py = el.y + dy[i];

          if (px < 0 || px >= n || py < 0 || py >= m)
            continue;

          if (matrix[px][py] == 1) {
            queue.offer(new Pair(px, py, el.distance + 1));
            matrix[px][py] = 2;
          }
        }
      }

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
          if (matrix[i][j] == 1)
            return -1;
        }
      }
      return ans;
    }

    private static class Pair {
      public int x;
      public int y;
      public int distance;

      public Pair(int x, int y, int distance) {
        this.x = x;
        this.y = y;
        this.distance = distance;
      }
    }
  }
}