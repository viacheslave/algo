package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/problems/remove-stones-to-minimize-the-total/
 * Submission: https://leetcode.com/submissions/detail/538058706/
 */
public class P1962 {
  class Solution {
    public int minStoneSum(int[] piles, int k) {
      var pq = new PriorityQueue<Integer>(Comparator.reverseOrder());

      for (var i : piles)
        pq.add(i);

      var sum = Arrays.stream(piles).sum();

      while (k > 0) {
        var el = pq.poll();

        var rem = el / 2;

        sum -= rem;
        pq.add(el - rem);

        k--;
      }

      return sum;
    }
  }
}