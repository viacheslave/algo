package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/number-of-flowers-in-full-bloom/
 * Submission: https://leetcode.com/submissions/detail/688042147/
 */
public class P2251 {
  class Solution {
    public int[] fullBloomFlowers(int[][] flowers, int[] persons) {
      Arrays.sort(flowers, Comparator.comparingInt(x -> x[0]));
      var pq = new PriorityQueue<Integer>();

      // build a treemap
      var treeMap = new TreeMap<Integer, Integer>();

      var running = 0;
      for (var f : flowers) {
        var up = f[0];

        while (!pq.isEmpty() && pq.peek() < up) {
          running--;
          var item = pq.poll();
          treeMap.put(item + 1, running);
        }

        running++;
        treeMap.put(up, running);

        pq.offer(f[1]);
      }

      // rest of PQ
      while (!pq.isEmpty()) {
        running--;
        var item = pq.poll();
        treeMap.put(item + 1, running);
      }

      var ans = new int[persons.length];

      // check each person against the treemap
      for (int i = 0; i < persons.length; i++) {
        int person = persons[i];
        var entry = treeMap.floorEntry(person);

        if (entry == null) {
          ans[i] = 0;
        }
        else {
          ans[i] = entry.getValue();
        }
      }

      return ans;
    }
  }
}