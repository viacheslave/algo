package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/problems/number-of-strings-that-appear-as-substrings-in-word/
 * Submission: https://leetcode.com/submissions/detail/539352104/
 */
public class P1967 {
  class Solution {
    public int numOfStrings(String[] patterns, String word) {
      return (int) Arrays.stream(patterns).filter(s -> word.indexOf(s) != -1).count();
    }
  }
}