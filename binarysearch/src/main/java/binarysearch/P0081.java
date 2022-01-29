package binarysearch;

import binarysearch.templates.LLNode;

import java.util.Comparator;
import java.util.PriorityQueue;

/*
 * Problem: https://binarysearch.com/problems/Central-Linked-List
 * Submission: https://binarysearch.com/problems/Central-Linked-List/submissions/7389605
 */
public class P0081 {
  class Solution {
    public int solve(LLNode node) {
      if (node == null)
        return 0;

      var count = 0;
      var current = node;
      while (current != null) {
        count++;
        current = current.next;
      }

      var target = count / 2;
      count = 0;

      current = node;
      while (current != null) {
        current = current.next;

        count++;
        if (count == target)
          return current.val;
      }

      return -1;
    }
  }
}