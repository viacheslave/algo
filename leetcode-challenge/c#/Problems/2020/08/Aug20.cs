using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/551/week-3-august-15th-august-21st/3430/
  ///    https://leetcode.com/submissions/detail/383733486/?from=/explore/challenge/card/august-leetcoding-challenge/551/week-3-august-15th-august-21st/3430/
  /// </summary>
  internal class Aug20
  {
    /**
    /* Definition for singly-linked list. */
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
   
    public class Solution
    {
      public void ReorderList(ListNode head)
      {
        if (head == null)
          return;

        Stack<ListNode> s = new Stack<ListNode>();

        var current = head;
        while (current != null)
        {
          s.Push(current);
          current = current.next;
        }

        current = head;
        var topStack = s.Pop();

        while (current != topStack)
        {
          if (current.next == topStack)
            break;

          var tmpNext = current.next;
          current.next = topStack;
          topStack.next = tmpNext;

          current = tmpNext;
          topStack = s.Pop();
        }

        topStack.next = null;
      }
    }
  }
}
