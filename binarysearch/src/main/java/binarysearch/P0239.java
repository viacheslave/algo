package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Fair-Pay
 * Submission: https://binarysearch.com/problems/Fair-Pay/submissions/7315545
 */
public class P0239 {
  class Solution {
    public int solve(int[] ratings) {
      if (ratings.length == 0)
        return 0;

      // candy

      var left = new int[ratings.length];
      var right = new int[ratings.length];

      left[0] = 1;
      right[ratings.length - 1] = 1;

      for (var i = 1; i < ratings.length; i++) {
        if (ratings[i] > ratings[i - 1]) {
          left[i] = left[i - 1] + 1;
        }
        else {
          left[i] = 1;
        }
      }

      for (var i = ratings.length - 2; i >= 0; i--) {
        if (ratings[i] > ratings[i + 1]) {
          right[i] = right[i + 1] + 1;
        }
        else {
          right[i] = 1;
        }
      }

      var ans = new int[ratings.length];

      for (int i = 0; i < ratings.length; i++) {
        ans[i] = Math.max(left[i], right[i]);
      }

      return Arrays.stream(ans).sum();
    }
  }
}