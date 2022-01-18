package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Three-Way-String-Split-with-Equal-Ones
 * Submission: https://binarysearch.com/problems/Three-Way-String-Split-with-Equal-Ones/submissions/6828607
 */
public class P0911 {
  class Solution {
    public int solve(String s) {
      var ones = new ArrayList<Integer>();

      for (int i = 0; i < s.length(); i++) {
        if (s.charAt(i) == '1')
          ones.add(i);
      }

      if (ones.size() == 0) {
        var a = 1L * (s.length() - 1) * (s.length() - 2) / 2;
        return (int)(a % 1_000_000_007);
      }

      if (ones.size() % 3 != 0)
        return 0;

      var left = ones.size() / 3 - 1;
      var right = 2 * ones.size() / 3 - 1;

      var leftdiff = ones.get(left + 1) - ones.get(left);
      var rightdiff = ones.get(right + 1) - ones.get(right);

      long ans = 1L * leftdiff * rightdiff;
      return (int)(ans % 1_000_000_007);
    }
  }
}