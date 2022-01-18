package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Comparator;
import java.util.TreeMap;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/two-best-non-overlapping-events/
 * Submission: https://leetcode.com/submissions/detail/589116322/
 */
public class P2054 {
  class Solution {
    public int maxTwoEvents(int[][] events) {
      if (events.length == 0)
        return 0;

      // build two treemaps
      // 1. max value sorted by end
      // 2. max value sorted by start
      var sortedByStart = Arrays
        .stream(events)
        .sorted((a1, a2) -> a2[0] - a1[0])
        .collect(Collectors.toList());

      var sortedByEnd = Arrays
        .stream(events)
        .sorted((a1, a2) -> a1[1] - a2[1])
        .collect(Collectors.toList());

      var prefixStart = new TreeMap<Integer, Integer>();
      var prefixEnd = new TreeMap<Integer, Integer>();

      var max = Integer.MIN_VALUE;
      for (var s : sortedByStart) {
        max = Math.max(max, s[2]);
        prefixStart.put(s[0], max);
      }

      max = Integer.MIN_VALUE;
      for (var s : sortedByEnd) {
        max = Math.max(max, s[2]);
        prefixEnd.put(s[1], max);
      }

      var ans = Arrays.stream(events).map(x -> x[2])
        .max(Comparator.naturalOrder())
        .get();

      // iterate over all ends
      // pick first start to the right and its max value
      for (var e : prefixEnd.entrySet()) {
        var end = e.getKey();

        var rightEntry = prefixStart.ceilingEntry(end + 1);
        if (rightEntry != null) {
          ans = Math.max(ans, e.getValue() + rightEntry.getValue());
        }
      }

      return ans;
    }
  }
}