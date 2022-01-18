package com.vzh.leetcode;

import java.util.Arrays;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/find-greatest-common-divisor-of-array/
 * Submission: https://leetcode.com/submissions/detail/543500659/
 */
public class P1979 {
  class Solution {
    public int findGCD(int[] nums) {
      var min = Arrays.stream(nums).min().getAsInt();
      var max = Arrays.stream(nums).max().getAsInt();

      var gdc = 1;

      for (var i = 2; i <= 1000; i++) {
        while (max % i == 0 && min % i == 0) {
          gdc *= i;
          max /= i;
          min /= i;
        }
      }

      return gdc;
    }
  }
}