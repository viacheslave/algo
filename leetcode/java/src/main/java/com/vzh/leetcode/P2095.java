
package com.vzh.leetcode;

import com.vzh.leetcode.helpers.ListNode;
import com.vzh.leetcode.helpers.TreeNode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list/
 * Submission: https://leetcode.com/submissions/detail/597934568/
 */
public class P2095 {
  class Solution {
    public ListNode deleteMiddle(ListNode head) {
      if (head == null)
        return null;

      var current = head;
      var count = 0;

      while (current != null) {
        count++;
        current = current.next;
      }

      var index = count / 2;
      if (index == 0)
        return null;

      ListNode previousNode = null;
      current = head;
      int i = 0;

      while (i != index) {
        previousNode = current;
        current = current.next;
        i++;
      }

      if (previousNode != null) {
        previousNode.next = current.next;
      }

      return head;
    }
  }
}