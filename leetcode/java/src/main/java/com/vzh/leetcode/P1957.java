package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/problems/delete-characters-to-make-fancy-string/
 * Submission: https://leetcode.com/submissions/detail/539355769/
 */
public class P1957 {
  class Solution {
    public String makeFancyString(String s) {
      var sb = new StringBuilder();

      for (var ch : s.toCharArray()) {
        if (sb.length() <= 1) {
          sb.append(ch);
          continue;
        }

        if (ch == sb.charAt(sb.length() - 1) && ch == sb.charAt(sb.length() - 2))
          continue;

        sb.append(ch);
      }

      return sb.toString();
    }
  }
}