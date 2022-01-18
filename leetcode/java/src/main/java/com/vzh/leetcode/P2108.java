package com.vzh.leetcode;

/*
 * Problem: https://leetcode.com/problems/find-first-palindromic-string-in-the-array/
 * Submission: https://leetcode.com/submissions/detail/603983838/
 */
public class P2108 {
  class Solution {
    public String firstPalindrome(String[] words) {
      for (var s : words) {
        if (isPalindromic(s))
          return s;
      }

      return "";
    }

    public boolean isPalindromic(String s) {
      for (int i = 0; i < s.length(); i++) {
        if (s.charAt(i) != s.charAt(s.length() - 1 - i))
          return false;
      }

      return true;
    }
  }
}