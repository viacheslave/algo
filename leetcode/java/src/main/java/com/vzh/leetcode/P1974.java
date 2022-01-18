package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/minimum-time-to-type-word-using-special-typewriter/
 * Submission: https://leetcode.com/submissions/detail/543496930/
 */
public class P1974 {
  class Solution {
    public int minTimeToType(String word) {
      var pos = (int) 'a';
      var ans = 0;

      for (var ch : word.toCharArray()) {
        var steps = 0;
        if (ch != pos) {
          var min = Math.min(pos, ch);
          var max = Math.max(pos, ch);

          steps = Math.min(max - min, min + 26 - max);
        }

        ans += steps + 1;
        pos = ch;
      }

      return ans;
    }
  }
}