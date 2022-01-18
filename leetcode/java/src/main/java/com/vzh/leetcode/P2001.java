package com.vzh.leetcode;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/reverse-prefix-of-word/
 * Submission: https://leetcode.com/submissions/detail/556119358/
 */
public class P2001 {
  class Solution {
    public String reversePrefix(String word, char ch) {
      var sb = new StringBuilder();

      var index = word.indexOf(ch);
      if (index == -1)
        return word;

      sb.append(word.substring(0, index + 1)).reverse();
      sb.append(word.substring(index + 1));

      return sb.toString();
    }
  }
}