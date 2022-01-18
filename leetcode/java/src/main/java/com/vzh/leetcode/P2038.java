package com.vzh.leetcode;

import java.util.ArrayList;

/*
 * Problem: https://leetcode.com/problems/remove-colored-pieces-if-both-neighbors-are-the-same-color/
 * Submission: https://leetcode.com/submissions/detail/572630347/
 */
public class P2038 {
  class Solution {
    public boolean winnerOfGame(String colors) {
      var ofA = get(colors, 'A');
      var ofB = get(colors, 'B');

      return ofA > ofB;
    }

    private int get(String colors, char ch) {
      var ans = new ArrayList<int[]>();

      var start = -1;
      for (var i = 0; i < colors.length(); i++) {
        if (colors.charAt(i) == ch) {
          if (start == -1) {
            start = i;
            continue;
          }
        }

        if (colors.charAt(i) != ch) {
          if (start != -1) {
            ans.add(new int[]{start, i - 1});
            start = -1;
          }
        }
      }

      if (colors.charAt(colors.length() - 1) == ch) {
        ans.add(new int[]{start, colors.length() - 1});
      }

      var count = 0;
      for (var pair : ans) {
        if (pair[1] - pair[0] > 1) {
          count += pair[1] - pair[0] - 1;
        }
      }

      return count;
    }
  }
}