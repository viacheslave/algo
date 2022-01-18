using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3486/
  ///    https://leetcode.com/submissions/detail/405607587/?from=/explore/challenge/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3486/
  /// </summary>
  internal class Oct07
  {
    /**
    /* Definition for singly-linked list. */
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
 
    public class Solution
    {
      public ListNode RotateRight(ListNode head, int k)
      {
        if (head == null || head.next == null)
          return head;

        var length = 0;
        var current = head;

        while (current != null)
        {
          length++;
          current = current.next;
        }

        ListNode prevNode = null;
        current = head;
        var tail = current;

        k = k % length;
        if (k == 0)
          return head;

        var index = 0;

        while (current != null)
        {
          if (length - k - 1 == index)
          {
            prevNode = current;
          }

          index++;

          if (current.next == null)
            tail = current;

          current = current.next;
        }


        var newhead = prevNode.next;
        prevNode.next = null;
        tail.next = head;

        return newhead;
      }
    }
  }
}
