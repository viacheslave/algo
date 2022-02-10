package binarysearch;

import java.util.Arrays;
import java.util.Comparator;

/*
 * Problem: https://binarysearch.com/problems/Line-Segment
 * Submission: https://binarysearch.com/problems/Line-Segment/submissions/7508106
 */
public class P0138 {
  class Solution {
    public boolean solve(int[][] coordinates) {
      Arrays.sort(coordinates, Comparator.comparingInt(a -> a[0]));

      var slope = getSlope(coordinates, 0, 1);

      for (int i = 1; i < coordinates.length - 1; i++) {
        var s = getSlope(coordinates, i, i + 1);
        if (s != slope)
          return false;
      }

      return true;
    }

    private double getSlope(int[][] coordinates, int i1, int i2) {
      return
        1d * (coordinates[i2][1] - coordinates[i1][1]) / (coordinates[i2][0] - coordinates[i1][0]);
    }
  }
}