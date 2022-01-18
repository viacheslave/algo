package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

/*
 * Problem: https://leetcode.com/problems/execution-of-all-suffix-instructions-staying-in-a-grid/
 * Submission: https://leetcode.com/submissions/detail/607949656/
 */
public class P2120 {
  class Solution {
    public int[] executeInstructions(int n, int[] startPos, String s) {
      var st = new Point(startPos[0], startPos[1]);

      var ans = new int[s.length()];

      for (int i = 0; i < s.length(); i++) {
        var pos = new Point(st.r, st.c);

        for (int j = i; j < s.length(); j++) {
          var ch = s.charAt(j);
          switch (ch) {
            case 'L' : pos.c--; break;
            case 'R' : pos.c++; break;
            case 'U' : pos.r--; break;
            case 'D' : pos.r++; break;
          }

          if (pos.r < 0 || pos.c < 0 || pos.r >= n || pos.c >= n) {
            ans[i] = j - i;
            break;
          }

          if (j == s.length() - 1) {
            ans[i] = j - i + 1;
          }
        }
      }

      return ans;
    }

    class Point {
      public int r;
      public int c;

      public Point(int r, int c) {
        this.r = r;
        this.c = c;
      }
    }
  }
}