package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;

/*
 * Problem: https://binarysearch.com/problems/Range-Update
 * Submission: https://binarysearch.com/problems/Range-Update/submissions/7294790
 */
public class P0356 {
  class Solution {
    public int[] solve(int[] nums, int[][] operations) {
      Arrays.sort(operations, Comparator.comparingInt(x -> x[0]));

      var pq = new PriorityQueue<Inc>(Comparator.comparingInt(x -> x.index));

      for (var i = 0; i < operations.length; i++) {
        var operation = operations[i];

        var left = operation[0];
        var right = operation[1];
        var inc = operation[2];

        pq.offer(new Inc(left, inc));
        pq.offer(new Inc(right + 1, -inc));
      }

      var increment = 0;
      var el = pq.poll();

      while (!pq.isEmpty()) {
        var nx = pq.poll();
        increment += el.increment;

        for (int i = el.index; i < nx.index; i++) {
          nums[i] += increment;
        }

        el = nx;
      }

      return nums;
    }

    private static class Inc {
      public int index;
      public int increment;

      public Inc(int index, int decrement) {
        this.index = index;
        this.increment = decrement;
      }
    }
  }
}