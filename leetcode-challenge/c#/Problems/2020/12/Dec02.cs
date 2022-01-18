using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3552/
  ///    https://leetcode.com/submissions/detail/426369827/?from=/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3552/
  /// </summary>
  internal class Dec02
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

      /** @param head The linked list's head.
          Note that the head is guaranteed to be not null, so it contains at least one node. */

      public int _length = 1;

      public Random _rnd = new Random((int)DateTime.Now.Ticks);

      public ListNode _head;

      public Solution(ListNode head)
      {
        if (head == null)
          return;

        _head = head;

        var current = head;
        while (current.next != null)
        {
          _length++;
          current = current.next;
        }
      }

      /** Returns a random node's value. */
      public int GetRandom()
      {
        var index = _rnd.Next(_length);

        var current = _head;
        var i = 0;

        while (i < index)
        {
          i++;
          current = current.next;
        }

        return current.val;
      }
    }

    /**
    * Your Solution object will be instantiated and called as such:
    * Solution obj = new Solution(head);
    * int param_1 = obj.GetRandom();
    */
  }
}
