package com.vzh.leetcode;

import com.vzh.leetcode.helpers.ListNode;

/*
 * Problem: https://leetcode.com/problems/count-integers-with-even-digit-sum/
 * Submission: https://leetcode.com/submissions/detail/645254654/
 */
public class P2180 {
  class Solution {
    public int countEven(int num) {
      var ans = 0;

      for (var i = 0; i < 10; i++) {
        for (int j = 0; j < 10; j++) {
          for (int k = 0; k < 10; k++) {
            if (100 * i + 10 * j + k <= num) {
              if ((i + j + k != 0) && (i + j + k) % 2 == 0) {
                ans++;
              }
            }
          }
        }
      }

      return ans;
    }
  }
}