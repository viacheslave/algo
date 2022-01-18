using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3517/
  ///    https://leetcode.com/submissions/detail/415886594/?from=/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3517/
  /// </summary>
  internal class Nov02
  {
    /**
     * Definition for singly-linked list.*/
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    
    public class Solution
    {
      public ListNode InsertionSortList(ListNode head)
      {
        if (head == null)
          return null;

        Stack<ListNode> stack = new Stack<ListNode>();
        var newHead = head;

        var current = head;

        while (current != null)
        {
          if (stack.Count == 0)
          {
            stack.Push(current);
            current = current.next;
            continue;
          }

          ListNode p = null;
          ListNode pp = null;

          if (stack.Count > 0)
            p = stack.Peek();

          while (p != null && current.val < p.val)
          {
            if (stack.Count > 0)
              p = stack.Pop();
            else p = null;

            if (stack.Count > 0)
              pp = stack.Peek();
            else pp = null;

            if (pp != null) pp.next = current;
            if (p != null) p.next = current.next;
            current.next = p;

            p = pp;

            if (stack.Count == 0 && p == null)
              newHead = current;
          }

          stack.Push(current);

          current = current.next;
        }
        return newHead;
      }
    }
  }
}
