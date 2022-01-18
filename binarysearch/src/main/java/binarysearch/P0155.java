package binarysearch;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.PriorityQueue;

/*
 * Problem: https://binarysearch.com/problems/Merging-K-Sorted-Lists
 * Submission: https://binarysearch.com/problems/Merging-K-Sorted-Lists/submissions/6665766
 */
public class P0155 {
  class Solution {
    public int[] solve(int[][] lists) {
      var pq = new PriorityQueue<En>(new Comparator<En>() {
        @Override
        public int compare(En o1, En o2) {
          return o1.value - o2.value;
        }
      });

      var indices = new int[lists.length];

      for (var i = 0; i < lists.length; i++) {
        if (lists[i].length > 0) {
          pq.add(new En(i, lists[i][0]));
          indices[i] = 1;
        }
      }

      var ans = new ArrayList<Integer>();

      while (!pq.isEmpty()) {
        var el = pq.poll();
        ans.add(el.value);

        var list = lists[el.index];
        if (list.length > indices[el.index]) {
          pq.add(new En(el.index, list[indices[el.index]++]));
        }
      }

      return ans.stream().mapToInt(x -> x).toArray();
    }

    public class En {
      public int index;
      public int value;

      public En(int index, int value) {
        this.index = index;
        this.value = value;
      }
    }
  }
}