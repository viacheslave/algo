package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Light-Bulb-Toggling
 * Submission: https://binarysearch.com/problems/Light-Bulb-Toggling/submissions/7120187
 */
public class P0357 {
  class Solution {
    public int solve(int n) {
      var maxSqrt = (int)Math.sqrt(n);

      var i = 1;
      while (i < maxSqrt) {
        if (i * i < n) {
          i++;
        }
      }

      return maxSqrt;
    }
  }
}