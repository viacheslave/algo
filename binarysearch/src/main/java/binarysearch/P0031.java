package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/One-Edit-Distance
 * Submission: https://binarysearch.com/problems/One-Edit-Distance/submissions/6910671
 */
public class P0031 {
  class Solution {
    public boolean solve(String s0, String s1) {
      if (Math.abs(s0.length() - s1.length()) > 1)
        return false;

      if (s0.equals(s1))
        return true;

      if (s0.length() == s1.length()) {
        var edits = 0;

        for (int i = 0; i < s1.length(); i++) {
          if (s0.charAt(i) != s1.charAt(i))
            edits++;
        }

        return edits <= 1;
      }

      var i = 0;
      var j = 0;
      var edits = 0;

      while (i < s0.length() && j < s1.length()) {
        if (s0.charAt(i) == s1.charAt(j)) {
          i++;
          j++;
          continue;
        }

        edits++;
        if (s0.length() > s1.length())
          i++;
        else
          j++;

        if (edits > 1)
          return false;
      }

      return true;
    }
  }
}