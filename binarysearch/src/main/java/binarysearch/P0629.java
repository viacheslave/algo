package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Minimum-Tree-From-Leaves
 * Submission: https://binarysearch.com/problems/Minimum-Tree-From-Leaves/submissions/7457847
 */
public class P0629 {
  class Solution {
    public int solve(int[] nums) {
      var dp = new HashMap<Pair, Result>();

      var ans = recursive(nums, dp, 0, nums.length - 1);
      return ans.value;
    }

    private Result recursive(int[] nums, HashMap<Pair, Result> dp, int start, int end) {
      if (start == end) {
        return new Result(nums[start], nums[start]);
      }

      var pair = new Pair(start, end);
      if (dp.containsKey(pair)) {
        return dp.get(pair);
      }

      var value = Integer.MAX_VALUE;
      var max = 0;

      for (int i = start; i < end; i++) {
        var left = recursive(nums, dp, start, i);
        var right = recursive(nums, dp, i + 1, end);

        max = Math.max(left.max, right.max);
        value = Math.min(
          value,
          left.value + right.value + (left.max * right.max));
      }

      dp.put(pair, new Result(value, max));
      return new Result(value, max);
    }

    private static class Result {
      public int value;
      public int max;

      public Result (int value, int max) {
        this.value = value;
        this.max = max;
      }
    }

    private static class Pair {
      public int item1;
      public int item2;

      public Pair(int item1, int item2) {
        this.item1 = item1;
        this.item2 = item2;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Pair pair = (Pair) o;
        return item1 == pair.item1 && item2 == pair.item2;
      }

      @Override
      public int hashCode() {
        return Objects.hash(item1, item2);
      }
    }
  }
}