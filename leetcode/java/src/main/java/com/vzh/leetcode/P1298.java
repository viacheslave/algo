package com.vzh.leetcode;

import java.util.HashSet;
import java.util.LinkedList;

/*
 * Problem: https://leetcode.com/problems/maximum-candies-you-can-get-from-boxes/
 * Submission: https://leetcode.com/submissions/detail/589650185/
 */
public class P1298 {
  class Solution {
    public int maxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) {
      // DFS
      var ans = 0;
      var ks = new HashSet<Integer>();
      var boxes = new HashSet<Integer>();

      var queue = new LinkedList<Integer>();
      var visited = new HashSet<Integer>();

      for (var b : initialBoxes)
        queue.add(b);

      while (!queue.isEmpty()) {
        var el = queue.poll();
        if (visited.contains(el))
          continue;

        ans += candies[el];

        // add new keys
        for (var k : keys[el])
          ks.add(k);

        // add new boxes
        for (var b : containedBoxes[el])
          boxes.add(b);

        // if new boxes are already opened, check them
        for (var b : containedBoxes[el])
          if (status[b] == 1)
            queue.add(b);

        // if new set of keys match new set of boxes, check them
        for (var k : ks) {
          if (boxes.contains(k)) {
            queue.add(k);
          }
        }

        visited.add(el);
      }

      return ans;
    }
  }
}