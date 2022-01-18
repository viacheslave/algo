package com.vzh.leetcode;

import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/escape-the-ghosts/
 * Submission: https://leetcode.com/submissions/detail/587669387/
 */
public class P0789 {
  class Solution {
    public boolean escapeGhosts(int[][] ghosts, int[] target) {
      var length = Math.abs(target[0]) + Math.abs(target[1]);

      for (var ghost : ghosts) {
        var gd = Math.abs(target[0] - ghost[0]) + Math.abs(target[1] - ghost[1]);
        if (gd <= length)
          return false;
      }

      return true;
    }
  }
}