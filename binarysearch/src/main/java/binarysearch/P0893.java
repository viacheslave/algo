package binarysearch;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Objects;

/*
 * Problem: https://binarysearch.com/problems/Count-Contained-Intervals
 * Submission: https://binarysearch.com/problems/Count-Contained-Intervals/submissions/7380598
 */
public class P0893 {
  class Solution {
    public int solve(int[][] intervals) {
      if (intervals.length <= 1)
        return 0;

      Arrays.sort(intervals, (a, b) -> a[0] == b[0] ? b[1] - a[1] : a[0] - b[0]);

      var currentEnd = intervals[0][1];
      var ans = 0;

      for (int i = 1; i < intervals.length; i++) {
        var start = intervals[i][0];
        var end = intervals[i][1];

        if (end <= currentEnd) {
          ans++;
        }
        else {
          currentEnd = end;
        }
      }

      return ans;
    }
  }
}