package com.vzh.leetcode;

/*
 * Problem: https://leetcode.com/problems/a-number-after-a-double-reversal/
 * Submission: https://leetcode.com/submissions/detail/607950678/
 */
public class P2119 {
  class Solution {
    public boolean isSameAfterReversals(int num) {
      var rev1 = Integer.parseInt(new StringBuilder(String.valueOf(num)).reverse().toString());
      var rev2 = Integer.parseInt(new StringBuilder(String.valueOf(rev1)).reverse().toString());

      return rev2 == num;
    }
  }
}