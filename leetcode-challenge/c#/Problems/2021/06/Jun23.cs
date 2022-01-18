using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/606/week-4-june-22nd-june-28th/3789/
  /// 
  /// </summary>
  internal class Jun23
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
      public ListNode ReverseBetween(ListNode head, int m, int n)
      {
        if (m == n)
          return head;

        var current = head;
        var index = 0;
        var pivot = head;
        ListNode pivotprev = null;
        ListNode currentprev = null;

        while (current != null)
        {
          index++;

          if (index == m - 1 && index > 0)
            pivotprev = current;

          if (index == m)
            pivot = current;

          if (m < index && index <= n)
          {
            var next = current.next;
            current.next = pivot;
            if (pivotprev != null)
              pivotprev.next = current;
            //else head = pivot;

            currentprev.next = next;

            // 
            pivot = current;
            current = currentprev;

            if (pivotprev == null) head = pivot;
          }

          currentprev = current;
          current = current.next;
        }

        return head;
      }
    }
  }
}
