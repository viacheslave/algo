package binarysearch;

import binarysearch.templates.LLNode;

import java.util.HashSet;

/*
 * Problem: https://binarysearch.com/problems/Interleaved-Linked-List
 * Submission: https://binarysearch.com/problems/Interleaved-Linked-List/submissions/7331377
 */
public class P0142 {
  class Solution {
    public LLNode solve(LLNode l0, LLNode l1) {
      var cl = l0;
      var cr = l1;

      var ans = new LLNode();
      var current = ans;

      while (cl != null || cr != null) {
        if (cl != null) {
          current.next = new LLNode();
          current.next.val = cl.val;

          current = current.next;
          cl = cl.next;
        }

        if (cr != null) {
          current.next = new LLNode();
          current.next.val = cr.val;

          current = current.next;
          cr = cr.next;
        }
      }

      return ans.next;
    }
  }
}