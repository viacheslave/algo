package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Number-of-Islands
 * Submission: https://binarysearch.com/problems/Number-of-Islands/submissions/7309689
 */
public class P0023 {
  class Solution {
    public int solve(int[][] matrix) {
      if (matrix.length == 0)
        return 0;

      var n = matrix.length;
      var m = matrix[0].length;
      var visited = new int[n][m];
      var ans = 0;

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
          if (matrix[i][j] == 1) {
            if (visited[i][j] == 1)
              continue;

            dfs(matrix, visited, i, j, n, m);
            ans++;
          }
        }
      }

      return ans;
    }

    private void dfs(int[][] matrix, int[][] visited, int i, int j, int n, int m) {
      if (visited[i][j] == 1)
        return;

      visited[i][j] = 1;

      var dx = new int[] {0,1,0,-1};
      var dy = new int[] {1,0,-1,0};

      for (var k = 0; k < dx.length; k++) {
        var px = i + dx[k];
        var py = j + dy[k];

        if (px < 0 || py < 0 || px >= n || py >= m)
          continue;

        if (visited[px][py] == 1)
          continue;

        if (matrix[px][py] == 0)
          continue;

        dfs(matrix, visited, px, py, n, m);
      }
    }
  }
}