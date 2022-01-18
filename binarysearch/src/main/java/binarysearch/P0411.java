package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Interval-Union
 * Submission: https://binarysearch.com/problems/Interval-Union/submissions/6881217
 */
public class P0411 {
  class Solution {
    public int[][] solve(int[][] intervals) {
      var intervalsList = Arrays.stream(intervals).sorted((a1, a2) -> a1[0] - a2[0]).collect(Collectors.toList());

      if (intervalsList.size() == 0)
        return new int[0][];

      if (intervalsList.size() == 1)
        return intervals;

      var res = new ArrayList<Integer[]>();
      var start = -1;
      var end = -1;

      for (var i = 0; i < intervalsList.size() - 1; i++) {
        if (start == -1) {
          start = intervalsList.get(i)[0];
          end = intervalsList.get(i)[1];
        }

        if (end >= intervalsList.get(i + 1)[0]) {
          end = Math.max(end, intervalsList.get(i + 1)[1]);
          if (i + 1 == intervalsList.size() - 1) {
            res.add(new Integer[] { start, end });
          }
          continue;
        }

        res.add(new Integer[] { start, end });
        start = -1;
        end = -1;
      }

      if (start == -1) {
        res.add(
          new Integer[] {
            intervalsList.get(intervalsList.size() - 1)[0],
            intervalsList.get(intervalsList.size() - 1)[1] });
      }

      var ans = new int[res.size()][];
      for (var i = 0; i < res.size(); i++) {
        ans[i] = new int[] { res.get(i)[0].intValue(), res.get(i)[1].intValue() };
      }

      return ans;
    }
  }
}