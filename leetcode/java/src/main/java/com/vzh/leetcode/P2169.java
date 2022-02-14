package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

/*
 * Problem: https://leetcode.com/problems/count-operations-to-obtain-zero/
 * Submission: https://leetcode.com/submissions/detail/640520781/
 */
public class P2169 {
  class Solution {
    public int countOperations(int num1, int num2) {
      var ans = 0;
      while (num1 != 0 && num2 != 0) {
        if (num1 > num2) num1 -= num2;
        else num2 -= num1;
        ans++;
      }
      return ans;
    }
  }
}