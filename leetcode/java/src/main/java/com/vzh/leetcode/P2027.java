package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/minimum-moves-to-convert-string/
 * Submission: https://leetcode.com/submissions/detail/583485493/
 */
public class P2027 {
  class Solution {
    public int minimumMoves(String s) {
      var start = -1;
      var ans = 0;

      for (var i = 0; i < s.length(); i++) {
        if (start == -1 && s.charAt(i) == 'X')
          start = i;
        if (start != -1 && (i == start + 2 || i == s.length() - 1)) {
          ans++;
          start = -1;
        }
      }

      return ans;
    }
  }
}