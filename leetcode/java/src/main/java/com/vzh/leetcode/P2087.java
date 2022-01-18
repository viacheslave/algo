
package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.HashMap;

/*
 * Problem: https://leetcode.com/problems/minimum-cost-homecoming-of-a-robot-in-a-grid/
 * Submission: https://leetcode.com/submissions/detail/593599809/
 */
public class P2087 {
  class Solution {
    public int minCost(int[] startPos, int[] homePos, int[] rowCosts, int[] colCosts) {
      if (startPos[0] == homePos[0] && startPos[1] == homePos[1])
        return 0;

      var dx = -new Integer(startPos[0]).compareTo(new Integer(homePos[0]));
      var dy = -new Integer(startPos[1]).compareTo(new Integer(homePos[1]));

      var ans = 0;

      if (dx != 0) {
        for (var r = startPos[0] + dx; ; r += dx) {
          ans += rowCosts[r];

          if (r == homePos[0])
            break;
        }
      }

      if (dy != 0) {
        for (var c = startPos[1] + dy; ; c += dy) {
          ans += colCosts[c];

          if (c == homePos[1])
            break;
        }
      }

      return ans;
    }
  }
}