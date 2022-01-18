package binarysearch;

import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.TreeSet;

/*
 * Problem: https://binarysearch.com/problems/As-Before-Bs
 * Submission: https://binarysearch.com/problems/As-Before-Bs/submissions/7175404
 */
public class P0310 {
  class Solution {
    public int solve(String s) {
      var as = new int[s.length()];
      var bs = new int[s.length()];

      // as - number of As left to the index
      // bs - number of Bs right to the index

      for (var i = 0; i < s.length(); i++) {
        if (i == 0) {
          as[i] = s.charAt(i) == 'A' ? 1 : 0;
          continue;
        }
        as[i] = s.charAt(i) == 'A' ? as[i - 1] + 1 : as[i - 1];
      }

      for (var i = s.length() - 1; i >= 0; i--) {
        if (i == s.length() - 1) {
          bs[i] = s.charAt(i) == 'B' ? 1 : 0;
          continue;
        }
        bs[i] = s.charAt(i) == 'B' ? bs[i + 1] + 1 : bs[i + 1];
      }

      // As are before Bs means that there's an index where
      // all to the left are As and all to the right are Bs

      var ans = Integer.MAX_VALUE;

      for (var i = 0; i < s.length(); i++) {
        var removeB = i - as[i];
        var removeA = s.length() - i - bs[i];

        ans = Math.min(ans, removeA + removeB);
      }

      if (ans == Integer.MAX_VALUE)
        ans = 0;

      return ans;
    }
  }
}