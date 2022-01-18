package com.vzh.leetcode;

import java.util.HashSet;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/minimum-non-zero-product-of-the-array-elements/
 * Submission: https://leetcode.com/submissions/detail/572211476/
 */
public class P1969 {
  class Solution {
    public int minNonZeroProduct(int p) {
      // every even element is 1
      // every odd element is 2^p - 2
      // last element is 2^p - 1

      var ans = 1L;
      var midElement = (long) Math.pow(2, p) - 2;
      var lastElement = (long) Math.pow(2, p) - 1;
      var iterations = lastElement / 2;
      var mod = 1_000_000_007;

      var pow = powerMod(midElement, iterations, mod);
      ans = pow * (lastElement % mod);

      return (int) (ans % mod);
    }

    public static long powerMod(long base, long exp, long mod) {
      long result = 1;
      base %= mod;
      while (exp > 0) {
        if ((exp & 1) != 0)
          result = (result * base) % mod;
        exp >>= 1;
        base = base * base % mod;
      }
      return result < 0 ? result + mod : result;
    }
  }
}