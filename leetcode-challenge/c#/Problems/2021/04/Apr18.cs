using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3712/
  /// 
  /// </summary>
  internal class Apr18
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
      public ListNode RemoveNthFromEnd(ListNode head, int n)
      {
        ListNode current = head;
        ListNode prev = null;

        for (int i = 0; ; i++)
        {
          if (i - n == 0)
            prev = head;

          if (current.next != null)
          {
            current = current.next;
            if (prev != null)
              prev = prev.next;

            continue;
          }
          break;
        }

        if (prev == null)
          return head.next;

        prev.next = prev.next.next;

        return head;
      }
    }
  }
}
