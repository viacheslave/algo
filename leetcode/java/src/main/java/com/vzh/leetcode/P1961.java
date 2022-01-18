package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/problems/check-if-string-is-a-prefix-of-array/
 * Submission: https://leetcode.com/submissions/detail/539353438/
 */
public class P1961 {
  class Solution {
    public boolean isPrefixString(String s, String[] words) {
      var sb = new StringBuilder();

      for (var word : words) {
        sb.append(word);

        if (sb.length() > s.length())
          return false;

        if (sb.length() == s.length())
          if (sb.toString().equals(s))
            return true;
      }

      return false;
    }
  }
}