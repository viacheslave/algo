package binarysearch;

import java.util.ArrayList;
import java.util.HashMap;

/*
 * Problem: https://binarysearch.com/problems/Rotate-by-90-Degrees-Counter-Clockwise
 * Submission: https://binarysearch.com/problems/Rotate-by-90-Degrees-Counter-Clockwise/submissions/7365061
 */
public class P0152 {
  class Solution {
    public int[][] solve(int[][] matrix) {
      var n = matrix.length;

      var l = n / 2;

      // if n is odd
      // we need to go one more row or col
      var k = l;
      if (n % 2 == 1)
        k++;

      for (var i = 0 ; i < l; i++) {
        for (int j = 0; j < k; j++) {
          // each point is a part of a circle of 4 items

          var points = new int[4][];

          points[0] = new int[] { i, j };
          points[1] = new int[] { j, n - i - 1 };
          points[2] = new int[] { n - i - 1, n - j - 1 };
          points[3] = new int[] { n - j - 1, i };

          rotate(matrix, points);
        }
      }

      return matrix;
    }

    private void rotate(int[][] matrix, int[][] points) {
      var temp = matrix[points[0][0]][points[0][1]];

      matrix[points[0][0]][points[0][1]] = matrix[points[1][0]][points[1][1]];
      matrix[points[1][0]][points[1][1]] = matrix[points[2][0]][points[2][1]];
      matrix[points[2][0]][points[2][1]] = matrix[points[3][0]][points[3][1]];
      matrix[points[3][0]][points[3][1]] = temp;
    }
  }
}