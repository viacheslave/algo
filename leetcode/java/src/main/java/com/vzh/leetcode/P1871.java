package com.vzh.leetcode;

import java.util.Comparator;
import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/problems/jump-game-vii/
 * Submission: https://leetcode.com/submissions/detail/587623757/
 */
public class P1871 {
  class Solution {
    public boolean canReach(String s, int minJump, int maxJump) {
      var dp = new int[s.length()];

      // the queue pq stores indices of s that are possible to jump forward from
      // higher indices are stored first, so we can check and discard them first
      var pq = new PriorityQueue<Integer>(Comparator.reverseOrder());

      for (var i = s.length() - 1; i >= 0; i--) {
        if (i == s.length() - 1) {
          dp[i] = s.charAt(i) == '0' ? 1 : 0;
          if (dp[i] == 1)
            pq.add(i);

          continue;
        }

        dp[i] = 0;

        if (s.charAt(i) != '0')
          continue;

        if (!pq.isEmpty()) {
          // remove most right out of bound indices
          while (pq.peek() != null && pq.peek() > (i + maxJump))
            pq.poll();

          var qi = pq.poll();
          if (qi != null && qi >= (i + minJump)) {
            dp[i] = 1;
            pq.add(i);
          }

          // add it back for future checks
          if (qi != null)
            pq.add(qi);
        }
      }

      return dp[0] == 1;
    }
  }
}