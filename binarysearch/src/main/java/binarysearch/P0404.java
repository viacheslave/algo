package binarysearch;

import binarysearch.templates.LLNode;
import binarysearch.templates.Tree;

import java.util.ArrayList;
import java.util.LinkedList;

/*
 * Problem: https://binarysearch.com/problems/Linked-List-Union
 * Submission: https://binarysearch.com/problems/Linked-List-Union/submissions/7414229
 */
public class P0404 {
  class Solution {
    public LLNode solve(LLNode ll0, LLNode ll1) {
      var ans = new LLNode();
      var cur = ans;

      var i = ll0;
      var j = ll1;

      Integer last = null;

      while (i != null && j != null) {
        if (i.val <= j.val) {
          if (last == null || last != i.val) {
            cur.next = new LLNode();
            cur.next.val = i.val;
            cur = cur.next;

            last = i.val;
          }

          i = i.next;
        }

        else {
          if (last == null || last != j.val) {
            cur.next = new LLNode();
            cur.next.val = j.val;
            cur = cur.next;

            last = j.val;
          }

          j = j.next;
        }
      }

      while (i != null) {
        if (last == null || last != i.val) {
          cur.next = new LLNode();
          cur.next.val = i.val;
          cur = cur.next;
        }
        i = i.next;
      }

      while (j != null) {
        if (last == null || last != j.val) {
          cur.next = new LLNode();
          cur.next.val = j.val;
          cur = cur.next;
        }
        j = j.next;
      }

      return ans.next;
    }
  }
}