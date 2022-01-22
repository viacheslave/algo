package binarysearch;

import java.util.ArrayList;
import java.util.Map;
import java.util.PriorityQueue;

/*
 * Problem: https://binarysearch.com/problems/Kth-Largest-Numbers-From-Stream
 * Submission: https://binarysearch.com/problems/Kth-Largest-Numbers-From-Stream/submissions/7353352
 */
public class P0932 {
  class KthLargestStream {
    private final PriorityQueue<Integer> pq = new PriorityQueue<>();
    private final int k;

    public KthLargestStream(int[] nums, int k) {
      this.k = k;

      for (int i : nums)
        add(i);
    }

    public int add(int val) {
      if (pq.size() <= k) {
        pq.offer(val);
        return pq.peek();
      }

      if (val < pq.peek())
        return pq.peek();

      pq.poll();
      pq.offer(val);

      return pq.peek();
    }
  }
}