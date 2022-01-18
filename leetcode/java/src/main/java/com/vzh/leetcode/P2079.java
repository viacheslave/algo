package com.vzh.leetcode;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/watering-plants/
 * Submission: https://leetcode.com/submissions/detail/590537538/
 */
public class P2079 {
  class Solution {
    public int wateringPlants(int[] plants, int capacity) {
      var start = 0;
      var ans = 0;

      // Two pointers
      while (start < plants.length) {
        // walk back
        if (start != 0) {
          ans += start;
        }

        var sum = plants[start];
        var end = start;

        while (end + 1 < plants.length && sum + plants[end + 1] <= capacity) {
          end++;
          sum += plants[end];
        }

        // make end steps
        ans += (end) + 1;
        start = end + 1;
      }

      return ans;
    }
  }
}