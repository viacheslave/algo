package com.vzh.leetcode;

import java.util.ArrayList;

/*
 * Problem: https://leetcode.com/problems/three-divisors/
 * Submission: https://leetcode.com/submissions/detail/532776951/
 */
public class P1952 {
  class Solution {
    public boolean isThree(int n) {
      var count = 0;
      for (var i = 1; i <= n; i++)
        if (n % i == 0)
          count++;

      return count == 3;
    }
  }
}