package binarysearch;

import java.util.Arrays;
import java.util.Comparator;
import java.util.HashMap;
import java.util.PriorityQueue;

/*
 * Problem: https://binarysearch.com/problems/Uber-Pool
 * Submission: https://binarysearch.com/problems/Uber-Pool/submissions/7265484
 */
public class P0238 {
  class Solution {
    public boolean solve(int[][] trips, int capacity) {

      Arrays.sort(trips, Comparator.comparingInt(x -> x[0]));

      var pq = new PriorityQueue<Drop>(Comparator.comparingInt(x -> x.point));

      var pass = 0;

      for (var trip : trips) {
        var from = trip[0];
        var to = trip[1];
        var passengers = trip[2];

        while (!pq.isEmpty() && pq.peek().point <= from) {
          var drop = pq.poll();
          pass -= drop.passengers;
        }

        pass += passengers;
        pq.offer(new Drop(to, passengers));

        if (pass > capacity)
          return false;
      }

      return true;
    }

    static class Drop {
      public int point;
      public int passengers;

      public Drop(int point, int passengers) {
        this.point = point;
        this.passengers = passengers;
      }
    }
  }
}