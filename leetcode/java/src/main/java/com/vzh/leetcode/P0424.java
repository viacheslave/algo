package com.vzh.leetcode;

/*
 * Problem: https://leetcode.com/problems/longest-repeating-character-replacement/
 * Submission: https://leetcode.com/submissions/detail/591080423/
 */
class P0424 {
  class Solution {
    public int characterReplacement(String s, int k) {
      var ans = Integer.MIN_VALUE;

      // for every uppercase char
      for (var i = 'A'; i <= 'Z'; i++)
        // sliding window
        // change every other character
        ans = Math.max(ans, longest(s, k, i));

      return ans;
    }

    private int longest(String s, int k, char i) {
      var left = 0;
      var right = 0;
      var repl = 0;
      var ans = 0;

      while (right < s.length()) {
        if (s.charAt(right) != i)
          repl++;

        while (repl > k) {
          if (s.charAt(left) != i) {
            repl--;
          }
          left++;
        }

        ans = Math.max(ans, right - left + 1);
        right++;
      }

      return ans;
    }
  }
}

