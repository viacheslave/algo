package com.vzh.leetcode;

/**
 * Problem: https://leetcode.com/problems/maximum-segment-sum-after-removals/
 * Submission: https://leetcode.com/submissions/detail/781411974/
 */
public class P2382 {
  class Solution {
    public long[] maximumSegmentSum(int[] nums, int[] removeQueries) {
      // store intervals sorted to find the right interval
      // store max sum intervals in PQ
      // precalculate prefix sums
      // mark intervals to skip

      var prefixSums = new long[nums.length + 1];

      for (var i = 0; i < nums.length; i++) {
        prefixSums[i + 1] = prefixSums[i] + nums[i];
      }

      var ans = new long[nums.length];

      var rootSegment = new Segment(0, removeQueries.length - 1, prefixSums[nums.length]);

      TreeMap<Integer, Segment> segments = new TreeMap<>();
      segments.put(0, rootSegment);

      PriorityQueue<Segment> pq = new PriorityQueue<>((a, b) -> {
        if (a.sum == b.sum)
          return 0;
        if (a.sum < b.sum)
          return 1;
        return -1;
      });

      pq.offer(rootSegment);

      for (var i = 0; i < removeQueries.length; i++) {
        var index = removeQueries[i];
        var segment = segments.floorEntry(index);

        var start = segment.getValue().start;
        var end = segment.getValue().end;

        var left = prefixSums[index] - prefixSums[start];
        var right = prefixSums[end + 1] - prefixSums[index + 1];

        segments.remove(start);

        segment.getValue().flag();

        if (index - 1 >= start) {
          var l = new Segment(start, index - 1, left);
          segments.put(start, l);
          pq.offer(l);
        }

        if (end >= index + 1) {
          var r =new Segment(index + 1, end, right);
          segments.put(index + 1, r);
          pq.offer(r);
        }

        while (!pq.isEmpty() && pq.peek().flag == 1)
          pq.poll();

        if (!pq.isEmpty()) {
          ans[i] = pq.peek().sum;
        }
      }

      return ans;
    }

    private static class Segment {
      public final int start;
      public final int end;
      public final long sum;
      public int flag = 0;

      public Segment(int start, int end, long sum) {
        this.start = start;
        this.end = end;
        this.sum = sum;
      }

      public void flag() {
        this.flag = 1;
      }
    }
  }
}
