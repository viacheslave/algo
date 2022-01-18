package com.vzh.leetcode;

import java.util.ArrayList;

/*
 * Problem: https://leetcode.com/problems/vowels-of-all-substrings/
 * Submission: https://leetcode.com/submissions/detail/583440854/
 */
public class P2063 {
  class Solution {
    public long countVowels(String word) {
      var ans = 0L;

      for (var i = 0; i < word.length(); i++) {
        var ch = word.charAt(i);
        if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u') {
          ans += 1L * (i + 1) * (word.length() - i);
        }
      }

      return ans;
    }
  }
}