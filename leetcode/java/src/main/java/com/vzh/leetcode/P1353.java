package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;
import java.util.TreeMap;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/maximum-number-of-events-that-can-be-attended/
 * Submission: https://leetcode.com/submissions/detail/591443123/
 */
public class P1353 {
  class Solution {
    public int maxEvents(int[][] events) {
      var e = Arrays.stream(events).collect(Collectors.groupingBy(x -> x[0]));
      var min = Arrays.stream(events).map(x -> x[0]).min(Comparator.comparingInt(x -> x)).get();
      var max = Arrays.stream(events).map(x -> x[1]).max(Comparator.comparingInt(x -> x)).get();

      // Min-Heap
      // Greedy
      var pq = new PriorityQueue<Event>((a, b) -> a.to - b.to);
      var ans = 0;

      for (var day = min; day <= max; day++) {

        // add events to PQ that start current day
        // PQ is min PQ by end date
        var eve = e.get(day);
        if (eve != null) {
          for (var i: eve)
            pq.add(new Event(i[0], i[1]));
        }

        // remove events from PQ that are past current day
        Event pqItem = pq.poll();
        while (pqItem != null && pqItem.to < day)
          pqItem = pq.poll();

        // current valid event
        if (pqItem != null)
          ans++;
      }

      return ans;
    }

    public class Event {
      public int from;
      public int to;

      public Event(int from, int to) {
        this.from = from;
        this.to = to;
      }
    }
  }
}