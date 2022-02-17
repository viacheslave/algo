package binarysearch;

import java.util.TreeMap;

/*
 * Problem: https://binarysearch.com/problems/Next-Binary-Permutation
 * Submission: https://binarysearch.com/problems/Next-Binary-Permutation/submissions/7556354
 */
public class P0354 {
  class Solution {
    public int solve(int n) {
      for (var i = 1; i < 31; i++) {
        if ((n & (1 << i)) == 0 && (n & (1 << (i - 1))) == (1 << (i - 1))) {
          n -= (1 << (i - 1));
          n += (1 << (i));

          // bubble sort
          for (var j = 0; j < i - 1; j++) {
            for (var k = 0; k < i - 1; k++) {
              if ((n & (1 << k)) == 0 && (n & (1 << (k + 1))) == (1 << (k + 1))) {
                n -= (1 << (k + 1));
                n += (1 << (k));
              }
            }
          }

          return n;
        }
      }

      // 0110
      // 1010

      // 01100
      // 10100
      // 10001

      return n;
    }
  }
}