package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/final-value-of-variable-after-performing-operations/
 * Submission: https://leetcode.com/submissions/detail/557454006/
 */
public class P2011 {
  class Solution {
    public int finalValueAfterOperations(String[] operations) {
      var ans = 0;
      for (int i = 0; i < operations.length; i++) {
        if (operations[i].charAt(1) == '+')
          ans++;
        else
          ans--;
      }
      return ans;
    }
  }
}