package binarysearch;

import binarysearch.templates.LLNode;

import java.util.PriorityQueue;

/*
 * Problem: https://binarysearch.com/problems/One-Integer
 * Submission: https://binarysearch.com/problems/One-Integer/submissions/7531314
 */
public class P0345 {
  class Solution {
    public int solve(int[] nums) {
      var pq = new PriorityQueue<Integer>();
      var n = nums.length;

      if (n <= 1)
        return 0;

      var ans = 0;

      for (int num : nums) {
        pq.offer(num);
      }

      while (pq.size() != 1) {
        var a1 = pq.poll();
        var a2 = pq.poll();

        pq.offer(a1 + a2);
        ans += a1 + a2;
      }

      return ans;
    }
  }
}