package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Factory-Trail
 * Submission: https://binarysearch.com/problems/Factory-Trail/submissions/7606927
 */
public class P0370 {
  class Solution {
    public int solve(int n) {
      // idea:
      // zero is 10 or 2*5
      // so every 5 there's another zero

      var ans = 0;
      for (var i = 1; i <= 13; i++) {
        ans += n / (int)Math.pow(5, i);
      }
      return ans;
    }
  }
}