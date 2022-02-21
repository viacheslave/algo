package binarysearch;

import java.util.LinkedList;
import java.util.PriorityQueue;

/*
 * Problem: https://binarysearch.com/problems/Middle-Operable-Deque
 * Submission: https://binarysearch.com/problems/Middle-Operable-Deque/submissions/7599283
 */
public class P0943 {
  class MiddleOperableDeque {
    private final LinkedList<Integer> left = new LinkedList<>();
    private final LinkedList<Integer> right = new LinkedList<>();

    public MiddleOperableDeque() {
    }

    public void appendLeft(int val) {
      left.addFirst(val);
      rebalance();
    }

    public int popLeft() {
      if (left.size() + right.size() == 0)
        return -1;

      var val = left.pollFirst();
      if (val == null)
        val = right.pollFirst();

      rebalance();

      return val;
    }

    public void append(int val) {
      right.addLast(val);
      rebalance();
    }

    public int pop() {
      if (left.size() + right.size() == 0)
        return -1;

      var val = right.pollLast();
      rebalance();

      return val;
    }

    public void appendMiddle(int val) {
      left.addLast(val);
      rebalance();
    }

    public int popMiddle() {
      if (left.size() + right.size() == 0)
        return -1;

      if (left.size() == right.size()) {
        var val = left.pollLast();
        rebalance();

        return val;
      }
      else {
        var val = right.pollFirst();
        rebalance();

        return val;
      }
    }

    private void rebalance() {
      while (right.size() > left.size() + 1) {
        left.addLast(right.pollFirst());
      }

      while (left.size() > right.size()) {
        right.addFirst(left.pollLast());
      }
    }
  }
}