package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/sum-of-beauty-of-all-substrings/
 * Submission: https://leetcode.com/submissions/detail/573884171/
 */
public class P1781 {
  class Solution {
    public int beautySum(String s) {
      var ans = 0;
      var prefix = new ArrayList<int[]>();
      prefix.add(new int[26]);

      var current = new int[26];
      for (var i = 0; i < s.length(); i++) {
        current[s.charAt(i) - 97]++;
        prefix.add(Arrays.copyOf(current, 26));
      }

      for (var i = 0; i < s.length(); i++) {
        for (var j = i; j < s.length(); j++) {
          var min = Integer.MAX_VALUE;
          var max = Integer.MIN_VALUE;

          for (var o = 0; o < 26; o++) {
            var res = prefix.get(j + 1)[o] - prefix.get(i)[o];

            if (res != 0) {
              min = Math.min(min, res);
              max = Math.max(max, res);
            }
          }

          ans += (max - min);
        }
      }

      return ans;
    }
  }
}