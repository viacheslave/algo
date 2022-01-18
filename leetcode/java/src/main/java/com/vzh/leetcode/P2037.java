package com.vzh.leetcode;

import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/minimum-number-of-moves-to-seat-everyone/
 * Submission: https://leetcode.com/submissions/detail/583491533/
 */
public class P2037 {
  class Solution {
    public int minMovesToSeat(int[] seats, int[] students) {
      Arrays.sort(seats);
      Arrays.sort(students);

      var ans = 0;
      for (var i = 0; i < seats.length; i++) {
        ans += Math.abs(seats[i] - students[i]);
      }

      return ans;
    }
  }
}