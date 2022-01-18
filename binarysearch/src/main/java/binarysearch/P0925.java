package binarysearch;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Objects;

/*
 * Problem: https://binarysearch.com/problems/Maximum-Product-Path-in-Matrix
 * Submission: https://binarysearch.com/problems/Maximum-Product-Path-in-Matrix/submissions/7095038
 */
public class P0925 {
  class Solution {
    public int solve(int[][] matrix) {
      var dp = new HashMap<Pair, MinMax>();

      dp.put(new Pair(0, 0), new MinMax(matrix[0][0], matrix[0][0]));

      DP(dp, matrix, new Pair(matrix.length - 1, matrix[0].length - 1));

      var value = dp.get(new Pair(matrix.length - 1, matrix[0].length - 1));
      if (value.x < 0 && value.y < 0)
        return -1;

      var mod = (int)1e9 + 7;
      return (int)(Math.max(value.x, value.y) % mod);
    }

    private MinMax DP(HashMap<Pair, MinMax> dp, int[][] grid, Pair p) {
      if (dp.containsKey(p))
        return dp.get(p);

      var min = Long.MIN_VALUE;
      var max = Long.MAX_VALUE;

      if (p.x == 0) {
        var point_c = DP(dp, grid, new Pair(p.x, p.y - 1));

        var values = new long[]{
          point_c.x * grid[p.x][p.y],
          point_c.y * grid[p.x][p.y]
        };

        min = Arrays.stream(values).min().getAsLong();
        max = Arrays.stream(values).max().getAsLong();
      }
      else if (p.y == 0) {
        var point_r = DP(dp, grid, new Pair(p.x - 1, p.y));

        var values = new long[]{
          point_r.x * grid[p.x][p.y],
          point_r.y * grid[p.x][p.y]
        };

        min = Arrays.stream(values).min().getAsLong();
        max = Arrays.stream(values).max().getAsLong();
      }
      else {
        var point_c = DP(dp, grid, new Pair(p.x, p.y - 1));
        var point_r = DP(dp, grid, new Pair(p.x - 1, p.y));

        var values = new long[]{
          point_c.x * grid[p.x][p.y],
          point_c.y * grid[p.x][p.y],
          point_r.x * grid[p.x][p.y],
          point_r.y * grid[p.x][p.y]
        };

        min = Arrays.stream(values).min().getAsLong();
        max = Arrays.stream(values).max().getAsLong();
      }

      dp.put(p, new MinMax(min, max));
      return dp.get(p);
    }

    class Pair {
      public int x;
      public int y;

      public Pair(int item1, int item2) {
        this.x = item1;
        this.y = item2;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Pair pair = (Pair) o;
        return x == pair.x && y == pair.y;
      }

      @Override
      public int hashCode() {
        return Objects.hash(x, y);
      }
    }

    class MinMax {
      public long x;
      public long y;

      public MinMax(long item1, long item2) {
        this.x = item1;
        this.y = item2;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        MinMax pair = (MinMax) o;
        return x == pair.x && y == pair.y;
      }

      @Override
      public int hashCode() {
        return Objects.hash(x, y);
      }
    }

  }
}