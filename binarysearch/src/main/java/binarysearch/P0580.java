package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Partition-String
 * Submission: https://binarysearch.com/problems/Partition-String/submissions/7312918
 */
public class P0580 {
  class Solution {
    public int[] solve(String s) {
      var min = new int[26];
      var max = new int[26];

      Arrays.fill(min, -1);
      Arrays.fill(max, -1);

      for (int i = 0; i < s.length(); i++) {
        var ch = s.charAt(i);

        if (min[ch - 97] == -1)
          min[ch - 97] = i;

        max[ch - 97] = i;
      }

      var ranges = new ArrayList<Range>();

      for (int i = 0; i < 26; i++) {
        if (min[i] != -1)
          ranges.add(new Range((char)(97 + i), min[i], max[i]));
      }

      var split = new ArrayList<Integer>();

      var start = -1;
      var pq = new PriorityQueue<Integer>();
      ranges.sort(Comparator.comparingInt(x -> x.from));

      // merge intervals
      for (var r : ranges) {
        var end = -1;

        while (!pq.isEmpty() && pq.peek() < r.from)
          end = pq.poll();

        if (pq.isEmpty() && end != -1) {
          split.add(end - start + 1);
          start = -1;
        }

        if (start == -1)
          start = r.from;

        pq.offer(r.to);
      }

      // last interval
      if (start != -1) {
        var e = -1;
        while (!pq.isEmpty())
          e = pq.poll();

        split.add(e - start + 1);
      }

      return split.stream().mapToInt(x -> x).toArray();
    }

    private static class Range {
      public char ch;
      public int from;
      public int to;

      public Range(char ch, int from, int to) {
        this.ch = ch;
        this.from = from;
        this.to = to;
      }
    }
  }
}