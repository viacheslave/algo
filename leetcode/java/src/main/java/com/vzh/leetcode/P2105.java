package com.vzh.leetcode;

/*
 * Problem: https://leetcode.com/problems/watering-plants-ii/
 * Submission: https://leetcode.com/submissions/detail/601855140/
 */
public class P2105 {
  class Solution {
    public int minimumRefill(int[] plants, int capacityA, int capacityB) {
      var a = 0;
      var b = plants.length - 1;

      var ca = capacityA;
      var cb = capacityB;

      var ans = 0;

      while (a <= b) {

        // same plant
        if (a == b) {
          if (ca >= cb) {
            if (ca < plants[a]) {
              ans++;
            }
          }
          else {
            if (cb < plants[b]) {
              ans++;
            }
          }

          a++; b--;
          continue;
        }

        // refill
        if (ca < plants[a]) {
          ans++;
          ca = capacityA;
        }

        if (cb < plants[b]) {
          ans++;
          cb = capacityB;
        }

        // spend
        ca -= plants[a];
        cb -= plants[b];

        a++; b--;
      }

      return ans;
    }
  }
}