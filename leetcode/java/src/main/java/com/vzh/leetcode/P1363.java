package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Comparator;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/largest-multiple-of-three/
 * Submission: https://leetcode.com/submissions/detail/591489776/
 */
class P1363 {
  class Solution {
    public String largestMultipleOfThree(int[] digits) {
      var items = Arrays.stream(digits).boxed()
        .sorted(Comparator.reverseOrder())
        .collect(Collectors.toList());

      var dp = new String[digits.length][3];
      dp[0][0] = "";
      dp[0][1] = "";
      dp[0][2] = "";

      dp[0][items.get(0) % 3] = items.get(0).toString();

      // Greedy
      // keep track of best value that divides 0, 1, 2
      for (int i = 1; i < items.size(); i++) {
        var digit = items.get(i);

        if (digit % 3 == 0) {
          dp[i][0] = greater(dp[i - 1][0], dp[i - 1][0], digit, 0);
          dp[i][1] = greater(dp[i - 1][1], dp[i - 1][0], digit, 1);
          dp[i][2] = greater(dp[i - 1][2], dp[i - 1][0], digit, 2);
        }
        else if (digit % 3 == 1) {
          dp[i][0] = greater(dp[i - 1][2], dp[i - 1][0], digit, 0);
          dp[i][1] = greater(dp[i - 1][0], dp[i - 1][1], digit, 1);
          dp[i][2] = greater(dp[i - 1][1], dp[i - 1][2], digit, 2);
        }
        else {
          dp[i][0] = greater(dp[i - 1][1], dp[i - 1][0], digit, 0);
          dp[i][1] = greater(dp[i - 1][2], dp[i - 1][1], digit, 1);
          dp[i][2] = greater(dp[i - 1][0], dp[i - 1][2], digit, 2);
        }
      }

      var ans = dp[digits.length - 1][0];

      var index = 0;
      while (index < ans.length() - 1 && ans.charAt(index) == '0') {
        index++;
      }

      return ans.substring(index);
    }

    private String greater(String s1, String s2, Integer digit, Integer mod) {
      if (s1 == "") {
        if (digit % 3 == mod)
          return digit.toString();
        return s2;
      }

      s1 = s1 + digit;

      if (s1.length() == s2.length()) {
        return s1.compareTo(s2) > 0 ? s1 : s2;
      }
      return s1.length() > s2.length() ? s1 : s2;
    }
  }
}