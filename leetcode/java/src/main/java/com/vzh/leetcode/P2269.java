package com.vzh.leetcode;

import java.util.TreeSet;

/**
 * Problem: https://leetcode.com/problems/find-the-k-beauty-of-a-number/
 * Submission: https://leetcode.com/submissions/detail/699905496/
 */
public class P2269 {
  class Solution {
    public int divisorSubstrings(int num, int k) {
      var numstr = String.valueOf(num);

      var ans = 0;
      for (var i = 0; i <= numstr.length() - k; i++) {
        var sub = numstr.substring(i, i + k);
        var subi = Integer.parseInt(sub);

        if (subi != 0 && num % subi == 0)
          ans++;
      }

      return ans;
    }
  }
}
