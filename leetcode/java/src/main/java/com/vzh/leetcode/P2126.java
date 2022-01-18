package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/destroying-asteroids/
 * Submission: https://leetcode.com/submissions/detail/611348832/
 */
class P2126 {
  class Solution {
    public boolean asteroidsDestroyed(int mass, int[] asteroids) {

      // Greedy
      Arrays.sort(asteroids);

      long m = mass;

      for (var i = 0; i < asteroids.length; i++) {
        if (m >= asteroids[i]) {
          m += asteroids[i];
        }
        else {
          return false;
        }
      }

      return true;
    }
  }
}