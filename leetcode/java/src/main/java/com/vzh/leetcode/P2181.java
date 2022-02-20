package com.vzh.leetcode;

import com.vzh.leetcode.helpers.ListNode;

import java.util.HashMap;
import java.util.Objects;
import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/problems/merge-nodes-in-between-zeros/
 * Submission: https://leetcode.com/submissions/detail/645251801/
 */
public class P2181 {
  class Solution {
    public ListNode mergeNodes(ListNode head) {
      var node = head.next;

      while (node.next != null) {
        if (node.next.val == 0) {
          var prev = node;
          node = node.next;
          // last node
          if (node.next == null) {
            prev.next = null;
            break;
          }
          continue;
        }

        node.val += node.next.val;
        node.next = node.next.next;
      }

      return head.next;
    }
  }
}