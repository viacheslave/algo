package com.vzh.leetcode;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/number-of-laser-beams-in-a-bank/
 * Submission: https://leetcode.com/submissions/detail/611353589/
 */
class P2125 {
  class Solution {
    public int numberOfBeams(String[] bank) {
      var bitsSet = Arrays.stream(bank).map(this::numberOfBits)
        .filter(b -> b > 0)
        .collect(Collectors.toList());

      if (bitsSet.size() <= 1) {
        return 0;
      }

      var current = bitsSet.get(0);
      var ans = 0;
      for (var i = 1; i < bitsSet.size(); i++) {
        ans += current * bitsSet.get(i);
        current = bitsSet.get(i);
      }

      return ans;
    }

    private Integer numberOfBits(String b) {
      var ans = 0;
      for (var ch : b.toCharArray()){
        if (ch == '1')
          ans++;
      }
      return ans;
    }
  }
}