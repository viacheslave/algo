package com.vzh.leetcode;

import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/problems/jump-game-vi/
 * Submission: https://leetcode.com/submissions/detail/587600872/
 */
public class P1696 {
  class Solution {
    public int maxResult(int[] nums, int k) {
      var dp = new int[nums.length];
      var pq = new PriorityQueue<QueueItem>();

      for (var i = nums.length - 1; i >= 0; i--) {
        var max = Integer.MIN_VALUE;
        dp[i] = nums[i];

        // the queue pq stores sorted dp values
        // we poll first item from the queue
        // if its index is out of bounds (i + k), we remove it
        // otherwise we re-add it to the queue
        if (!pq.isEmpty()) {
          var qi = pq.poll();
          while (qi.index > (i + k))
            qi = pq.poll();

          dp[i] = nums[i] + qi.value;
          pq.add(qi);
        }

        pq.add(new QueueItem(dp[i], i));
      }

      return dp[0];
    }

    public class QueueItem implements Comparable<QueueItem> {
      public int value;
      public int index;

      public QueueItem(int value, int index) {
        this.value = value;
        this.index = index;
      }

      @Override
      public int compareTo(QueueItem o) {
        return o.value - this.value;
      }
    }
  }
}