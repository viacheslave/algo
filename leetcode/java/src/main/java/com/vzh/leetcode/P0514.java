package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/freedom-trail/
 * Submission: https://leetcode.com/submissions/detail/620445703/
 */
public class P0514 {
  class Solution {
    public int findRotateSteps(String ring, String key) {

      var indices = new HashMap<Character, List<Integer>>();
      for (int i = 0; i < ring.length(); i++) {
        indices.putIfAbsent(ring.charAt(i), new ArrayList<>());
        indices.get(ring.charAt(i)).add(i);
      }

      var dp = new HashMap<Integer, Integer>(); // index -> cost

      // initial
      dp.put(0, 0);

      for (int i = 0; i < key.length(); i++) {
        var ch = key.charAt(i);
        var next = new HashMap<Integer, Integer>();
        var nextIndices = indices.get(ch);

        for (var e : dp.entrySet()) {
          var previousIndex = e.getKey();
          var cost = e.getValue();

          for (var nextIndex : nextIndices) {
            var diff = getDiff(previousIndex, nextIndex, ring.length());

            if (!next.containsKey(nextIndex)) {
              next.put(nextIndex, cost + diff + 1);
            }
            else {
              var min = Math.min(
                next.get(nextIndex),
                cost + diff + 1);

              next.put(nextIndex, min);
            }
          }
        }

        dp = next;
      }

      var ans = dp.values().stream().min(Comparator.naturalOrder()).get();
      return ans;
    }

    private int getDiff(int index1, int index2, int length) {
      if (index1 == index2) {
        return 0;
      }

      var min = Math.min(index1, index2);
      var max = Math.max(index1, index2);

      return Math.min(
        max - min,
        min + length - max);
    }
  }
}