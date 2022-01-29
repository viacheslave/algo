package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Number-of-Hops
 * Submission: https://binarysearch.com/problems/Number-of-Hops/submissions/7389502
 */
public class P0253 {
  class Solution {
    public int solve(int[] nums) {
      var n = nums.length;
      if (n <= 1)
        return 0;

      var maxEnd = nums[0];
      var count = 1;

      if (maxEnd >= n - 1)
        return count;

      for (var i = 0;; ) {

        var currentEnd = maxEnd;

        while (i <= currentEnd) {
          maxEnd = Math.max(i + nums[i], maxEnd);
          if (maxEnd >= n - 1)
            return count + 1;

          i++;
        }

        count++;
      }
    }
  }
}