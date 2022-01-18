package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/jump-game-iv
 * Submission: https://leetcode.com/submissions/detail/620376004/
 */
class P1345 {
  class Solution {
    public int minJumps(int[] arr) {
      if (arr.length == 1)
        return 0;

      var map = new HashMap<Integer, List<Integer>>();

      for (int i = 0; i < arr.length; i++) {
        map.putIfAbsent(arr[i], new ArrayList<>());
        map.get(arr[i]).add(i);
      }

      var visited = new HashSet<Integer>();
      visited.add(0);

      var pq = new LinkedList<Steps>();
      pq.add(new Steps(0,0));

      while (!pq.isEmpty()) {
        var el = pq.poll();

        var indices = new TreeSet<Integer>(Comparator.reverseOrder());
        indices.add(el.index + 1);
        indices.add(el.index - 1);
        indices.addAll(map.get(arr[el.index]));

        for (var i : indices) {
          if (visited.contains(i) || i < 0 || i == arr.length)
            continue;

          if (i == arr.length - 1)
            return el.steps + 1;

          visited.add(i);
          pq.offer(new Steps(i, el.steps + 1));
        }

        map.get(arr[el.index]).clear();
      }

      return -1;
    }

    private static class Steps {
      public int index;
      public int steps;

      public Steps(int index, int steps) {
        this.index = index;
        this.steps = steps;
      }
    }
  }
}