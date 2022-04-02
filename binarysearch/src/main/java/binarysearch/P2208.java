package binarysearch;

import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;
import java.util.Stack;

/*
 * Problem: https://leetcode.com/problems/minimum-operations-to-halve-array-sum/
 * Submission: https://leetcode.com/submissions/detail/663125963/
 */
public class P2208 {
  class Solution {
    public int halveArray(int[] nums) {
      var pq = new PriorityQueue<Double>(
        Comparator.reverseOrder()
      );

      for (var i : nums)
        pq.offer((double) i);

      double sum = Arrays.stream(nums).asDoubleStream().sum();
      double target = sum / 2.0;
      int ans = 0;

      while (sum > target) {
        var el = pq.poll();

        sum -= el;
        sum += el / 2.0;

        pq.offer(el / 2.0);
        ans++;
      }

      return ans;
    }
  }
}