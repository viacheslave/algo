package binarysearch;

import binarysearch.templates.LLNode;

/*
 * Problem: https://binarysearch.com/problems/Swap-Kth-Node-Values
 * Submission: https://binarysearch.com/problems/Swap-Kth-Node-Values/submissions/7154172
 */
public class P0994 {
  class Solution {
    public LLNode solve(LLNode node, int k) {
      if (node == null)
        return node;

      int index = 0;
      LLNode current = node;
      while (current != null) {
        current = current.next;
        index++;
      }

      int end = index - k - 1;

      LLNode left = null;
      LLNode right = null;

      index = 0;
      current = node;
      while (current != null) {
        if (index == k)
          left = current;

        if (index == end)
          right = current;

        current = current.next;
        index++;
      }

      int leftValue = left.val;
      int rightValue = right.val;

      left.val = rightValue;
      right.val = leftValue;

      return node;
    }
  }
}