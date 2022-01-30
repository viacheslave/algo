package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Longest-Interval
 * Submission: https://binarysearch.com/problems/Longest-Interval/submissions/7423062
 */
public class P0332 {
  class Solution {
    public int solve(int[][] intervals) {
      Arrays.sort(intervals, (o1, o2) -> {
        if (o1[0] == o2[0])
          return o1[1] - o2[1];
        return o1[0] - o2[0];
      });

      // sliding window
      var start = intervals[0][0];
      var maxSoFar = intervals[0][1];
      var ans = maxSoFar - start + 1;

      for (int i = 1; i < intervals.length; i++) {
        if (intervals[i][0] > maxSoFar) {
          start = intervals[i][0];
          maxSoFar = intervals[i][1];
        }
        else {
          maxSoFar = Math.max(maxSoFar, intervals[i][1]);
        }

        ans = Math.max(ans, maxSoFar - start + 1);
      }

      return ans;
    }
  }
}