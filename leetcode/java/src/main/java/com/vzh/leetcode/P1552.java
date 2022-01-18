
package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

/*
 * Problem: https://leetcode.com/problems/magnetic-force-between-two-balls/
 * Submission: https://leetcode.com/submissions/detail/590932645/
 */
public class P1552 {
  class Solution {
    public int maxDistance(int[] position, int m) {

      Arrays.sort(position);

      var min = 1;
      var max = (position[position.length - 1] - position[0]) / (m - 1);

      // get intervals
      var intervals = new int[position.length - 1];
      for (int i = 1; i < position.length; i++) {
        intervals[i - 1] = position[i] - position[i - 1];
      }

      // Binary Search
      while (true) {
        if (max - min < 2) {
          if (canPlace(intervals, max, m))
            return max;
          return min;
        }

        var mid = (min + max) >> 1;
        if (canPlace(intervals, mid, m))
          min = mid;
        else
          max = mid;
      }
    }

    private boolean canPlace(int[] intervals, int max, int m) {
      // Greedily try to put balls starting from left

      m--;
      var sum = 0;

      for (int i = 0; i < intervals.length; i++) {
        sum += intervals[i];
        if (sum >= max) {
          sum = 0;
          m--;

          if (m == 0)
            return true;
        }
      }
      return false;
    }
  }
}