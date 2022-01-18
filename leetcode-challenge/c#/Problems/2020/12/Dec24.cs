using System;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/572/week-4-december-22nd-december-28th/3579/
  ///    https://leetcode.com/submissions/detail/434009861/?from=explore&item_id=3579
  /// </summary>
  internal class Dec24
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
      public ListNode SwapPairs(ListNode head)
      {
        if (head == null)
          return head;

        if (head.next == null)
          return head;

        ListNode newhead = null;

        var current = head;
        ListNode prev = null;

        while (current != null)
        {
          if (current.next == null)
            break;

          var next = current.next;
          var nextnext = next.next;

          if (prev != null)
            prev.next = next;
          else
            newhead = next;

          next.next = current;
          current.next = nextnext;

          prev = current;
          current = nextnext;
        }

        return newhead;
      }
    }
  }
}
