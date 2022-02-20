package com.vzh.leetcode;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Objects;
import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/problems/construct-string-with-repeat-limit/
 * Submission: https://leetcode.com/submissions/detail/645244925/
 */
public class P2182 {
  class Solution {
    public String repeatLimitedString(String s, int repeatLimit) {
      var map = new HashMap<Character, Integer>();
      for (var ch : s.toCharArray()) {
        map.put(ch, map.getOrDefault(ch, 0) + 1);
      }

      var pq = new PriorityQueue<Ch>();
      for (var e : map.entrySet()) {
        pq.offer(new Ch(e.getKey(), e.getValue()));
      }

      var sb = new StringBuilder();

      while (!pq.isEmpty()) {
        var el = pq.poll();

        var append = Math.min(el.count, repeatLimit);

        for (var i = 0; i < append; i++)
          sb.append(el.ch);

        if (el.count > repeatLimit) {
          if (pq.isEmpty()) {
            break;
          }
          var second = pq.poll();
          sb.append(second.ch);

          if (second.count - 1 > 0)
            pq.offer(new Ch(second.ch, second.count - 1));

          if (el.count - repeatLimit > 0)
            pq.offer(new Ch(el.ch, el.count - repeatLimit));
        }
      }

      return sb.toString();
    }

    private static class Ch implements Comparable<Ch> {
      public char ch;
      public int count;

      public Ch(char ch, int count) {
        this.ch = ch;
        this.count = count;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Ch ch1 = (Ch) o;
        return ch == ch1.ch && count == ch1.count;
      }

      @Override
      public int hashCode() {
        return Objects.hash(ch, count);
      }

      @Override
      public int compareTo(Ch o) {
        return o.ch - this.ch;
      }
    }
  }
}