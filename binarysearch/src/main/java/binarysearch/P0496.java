package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Longest-Sign-Alternating-Subsequence
 * Submission: https://binarysearch.com/problems/Longest-Sign-Alternating-Subsequence/submissions/7414533
 */
public class P0496 {
  class Solution {
    public int solve(int[] nums) {
      var n = nums.length;
      var dp = new int[n][2];

      var neg = 0;
      var pos = 0;

      for (int i = 0; i < n; i++) {

        if (nums[i] < 0) {
          pos = Math.max(pos, neg + 1);
        } else {
          neg = Math.max(neg, pos + 1);
        }
      }

      return Math.max(neg, pos);
    }
  }
}