package binarysearch;

import binarysearch.templates.LLNode;

import java.util.LinkedList;
import java.util.Queue;

/*
 * Problem: https://binarysearch.com/problems/Leftmost-Deepest-Tree-Node
 * Submission: https://binarysearch.com/problems/Leftmost-Deepest-Tree-Node/submissions/6951748
 */
public class P0242 {
  class Solution {
    public LLNode solve(LLNode l0, LLNode l1) {
      if (l0 == null)
        return l1;

      if (l1 == null)
        return l0;

      var ans = new LLNode();
      var cl0 = l0;
      var cl1 = l1;
      var cans = ans;

      var carry = 0;

      while (true) {
        if (cl0 == null && cl1 == null) {
          if (carry == 0)
            break;

          cans.next = new LLNode();
          cans.next.val = 1;
          break;
        }

        var value = carry;
        if (cl0 != null)
          value += cl0.val;
        if (cl1 != null)
          value += cl1.val;

        carry = 0;
        if (value >= 10) {
          carry = 1;
          value -= 10;
        }

        var node = new LLNode();
        node.val = value;
        cans.next = node;
        cans = cans.next;

        if (cl0 != null)
          cl0 = cl0.next;

        if (cl1 != null)
          cl1 = cl1.next;
      }

      return ans.next;
    }
  }
}