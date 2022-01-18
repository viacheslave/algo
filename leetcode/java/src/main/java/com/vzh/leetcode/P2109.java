package com.vzh.leetcode;

/*
 * Problem: https://leetcode.com/problems/adding-spaces-to-a-string/
 * Submission: https://leetcode.com/submissions/detail/603983091/
 */
public class P2109 {
  class Solution {
    public String addSpaces(String s, int[] spaces) {
      var sb = new StringBuilder(s);

      for (int i = spaces.length - 1; i >= 0; i--) {
        sb.insert(spaces[i], ' ');
      }

      return sb.toString();
    }
  }
}