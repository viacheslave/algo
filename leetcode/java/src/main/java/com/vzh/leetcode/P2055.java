package com.vzh.leetcode;

import java.util.ArrayList;

/*
 * Problem: https://leetcode.com/problems/plates-between-candles/
 * Submission: https://leetcode.com/submissions/detail/583384725/
 */
public class P2055 {
  class Solution {
    public int[] platesBetweenCandles(String s, int[][] queries) {
      var prefixStart = new int[s.length()];
      var prefixEnd = new int[s.length()];

      var start = -1;
      var currentPlates = 0;

      for (var i = 1; i < s.length(); i++) {
        if (s.charAt(i) == '*' && s.charAt(i - 1) == '|')
          start = i - 1;

        if (s.charAt(i) == '|' && s.charAt(i - 1) == '*' && start != -1)
          currentPlates += i - start - 1;

        prefixStart[i] = currentPlates;
      }

      start = -1;
      currentPlates = 0;

      for (var i = s.length() - 2; i >= 0; i--) {
        if (s.charAt(i) == '*' && s.charAt(i + 1) == '|')
          start = i + 1;

        if (s.charAt(i) == '|' && s.charAt(i + 1) == '*' && start != -1)
          currentPlates += start - i - 1;

        prefixEnd[i] = currentPlates;
      }

      var ans = new ArrayList<Integer>();
      for (var query : queries) {
        var res = prefixStart[query[1]] + prefixEnd[query[0]] - prefixStart[prefixStart.length - 1];
        ans.add(res > 0 ? res : 0);
      }

      return ans.stream().mapToInt(x -> x).toArray();
    }
  }
}