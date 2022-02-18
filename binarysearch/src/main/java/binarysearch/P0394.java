package binarysearch;

import java.util.Arrays;
import java.util.Comparator;
import java.util.TreeMap;

/*
 * Problem: https://binarysearch.com/problems/Class-Scheduling
 * Submission: https://binarysearch.com/problems/Class-Scheduling/submissions/7575431
 */
public class P0394 {
  class Solution {
    public int solve(int[][] times) {
      if (times.length == 0)
        return 0;

      var treeMap = new TreeMap<Integer, Integer>();
      Arrays.sort(times, (a, b) -> {
        if (a[1] == b[1])
          return a[0] - b[0];
        return a[1] - b[1];
      });

      for (int[] time : times) {
        var start = time[0];
        var end = time[1];

        var value = Math.max(1, treeMap.getOrDefault(end, 0));

        var floor = treeMap.floorEntry(start - 1);
        if (floor != null) {
          value = Math.max(value, floor.getValue() + 1);
        }

        floor = treeMap.floorEntry(end - 1);
        if (floor != null) {
          value = Math.max(value, floor.getValue());
        }

        treeMap.put(end, value);
      }

      return treeMap.values().stream().max(Comparator.naturalOrder()).get();
    }
  }
}