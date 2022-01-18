package com.vzh.leetcode;

import java.util.HashMap;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/replace-the-substring-for-balanced-string/
 * Submission: https://leetcode.com/submissions/detail/591453906/
 */
class P1234 {
  class Solution {
    public int balancedString(String s) {
      int cQ = 0, cW = 0, cE = 0, cR = 0;

      for (int i = 0; i < s.length(); i++) {
        switch (s.charAt(i)) {
          case 'Q' : cQ++; break;
          case 'W' : cW++; break;
          case 'E' : cE++; break;
          case 'R' : cR++; break;
        }
      }

      // already balanced
      if (cQ == cW && cW == cE && cE == cR)
        return 0;

      var ans = Integer.MAX_VALUE;
      var pL = 0;
      var pR = 0;
      var state = new State(s.length() / 4, cQ, cW, cE, cR);

      // Sliding Window
      // check valid substring

      while (pR < s.length()) {
        var ch = s.charAt(pR);
        state.add(ch);

        while (pL <= pR && state.valid()) {
          ans = Math.min(ans, pR - pL + 1);
          state.remove(s.charAt(pL));
          pL++;
        }

        pR++;
      }

      return ans;
    }

    class State {
      int cQ = 0, cW = 0, cE = 0, cR = 0;
      int tQ = 0, tW = 0, tE = 0, tR = 0;

      int qu;
      public State(int qu, int cQ, int cW, int cE, int cR) {
        this.qu = qu;
        this.cQ = cQ;
        this.cW = cW;
        this.cE = cE;
        this.cR = cR;
      }

      public boolean valid() {
        int lQ = cQ - tQ,
          lW = cW - tW,
          lE = cE - tE,
          lR = cR - tR;

        return
          lQ <= qu && lW <= qu && lE <= qu && lR <= qu;
      }

      public void add(char ch) {
        switch (ch) {
          case 'Q' : tQ++; break;
          case 'W' : tW++; break;
          case 'E' : tE++; break;
          case 'R' : tR++; break;
        }
      }

      public void remove(char ch) {
        switch (ch) {
          case 'Q' : tQ--; break;
          case 'W' : tW--; break;
          case 'E' : tE--; break;
          case 'R' : tR--; break;
        }
      }
    }
  }
}