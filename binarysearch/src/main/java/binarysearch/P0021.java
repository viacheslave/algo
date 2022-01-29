package binarysearch;

import java.util.HashSet;

/*
 * Problem: https://binarysearch.com/problems/Subsequence-Strings
 * Submission: https://binarysearch.com/problems/Subsequence-Strings/submissions/7384324
 */
public class P0021 {
  class Solution {
    public boolean solve(String s1, String s2) {
      if (s1.isEmpty())
        return true;

      var a = 0;
      var b = 0;

      while (b < s2.length()) {
        if (s1.charAt(a) == s2.charAt(b)) {
          a++;
          b++;

          if (a == s1.length())
            return true;

          continue;
        }

        b++;
      }

      return false;
    }
  }
}