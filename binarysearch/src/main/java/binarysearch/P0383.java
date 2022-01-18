package binarysearch;

import java.util.HashSet;

/*
 * Problem: https://binarysearch.com/problems/Factorial-Sum
 * Submission: https://binarysearch.com/problems/Factorial-Sum/submissions/6648981
 */
public class P0383 {
  class Solution {
    public boolean solve(int n) {
      var factorials = new int[14];
      factorials[0] = 0;
      factorials[1] = 1;
      factorials[13] = Integer.MAX_VALUE;

      for (var i = 2; i < 13; i++)
        factorials[i] = factorials[i - 1] * i;

      var used = new HashSet<Integer>();

      while (true) {
        var reduced = false;
        for (var i = 13; i >= 1; i--) {
          if (factorials[i - 1] <= n && n < factorials[i] && !used.contains(i)) {
            n -= factorials[i - 1];
            reduced = true;
            used.add(i);
            break;
          }
        }

        if (!reduced)
          return false;

        if (n == 0)
          return true;
      }
    }
  }
}