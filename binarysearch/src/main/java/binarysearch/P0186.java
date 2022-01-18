package binarysearch;

import java.util.ArrayDeque;
import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Ascending-Cards
 * Submission: https://binarysearch.com/problems/Ascending-Cards/submissions/7305126
 */
public class P0186 {
  class Solution {
    public int[] solve(int[] cards) {
      Arrays.sort(cards);

      var deque = new ArrayDeque<Integer>();

      for (int i = 0; i < cards.length; i++) {
        var num = cards[cards.length - 1 - i];

        if (i < 2) {
          deque.addFirst(num);
          continue;
        }

        deque.addFirst(deque.removeLast());
        deque.addFirst(num);
      }

      return deque.stream().mapToInt(x -> x).toArray();
    }
  }
}