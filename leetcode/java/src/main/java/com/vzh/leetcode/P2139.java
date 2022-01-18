package com.vzh.leetcode;

/*
 * Problem: https://leetcode.com/problems/minimum-moves-to-reach-target-score/
 * Submission: https://leetcode.com/submissions/detail/621228349/
 */
class P2139 {
  class Solution {
    public int minMoves(int target, int maxDoubles) {
      var ans = 0;

      while (maxDoubles > 0) {
        if (target == 1)
          return ans;

        if (target % 2 == 0) {
          target >>= 1;
          maxDoubles--;
          ans++;
        }
        else {
          target--;
          ans++;
        }
      }

      ans += target - 1;
      return ans;
    }
  }
}