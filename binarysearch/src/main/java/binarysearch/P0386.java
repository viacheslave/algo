package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Coprime-Suspects
 * Submission: https://binarysearch.com/problems/Coprime-Suspects/submissions/6910224
 */
public class P0386 {
  class Solution {
    public int solve(int a, int b) {
      if (gcd(a, b) > 1)
        return 0;

      if (a % 2 == 0 && b % 2 == 0)
        return 0;

      if (a % 2 == 0 && b % 2 == 1 || a % 2 == 1 && b % 2 == 0)
        return 1;

      var o1 = gcd(b, a - 1);
      var o2 = gcd(b, a + 1);
      var o3 = gcd(b + 1, a);
      var o4 = gcd(b - 1, a);

      if (o1 > 1 || o2 > 1 || o3 > 1 || o4 > 1)
        return 1;

      return 2;
    }

    public int gcd(int a, int b) {
      if (a == b)
        return a;

      if (a > b)
        return gcd(a - b, b);
      else
        return gcd(a, b - a);
    }
  }
}