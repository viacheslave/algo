using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3707/
  /// 
  /// </summary>
  internal class Apr14
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
      public ListNode Partition(ListNode head, int x)
      {
        if (head == null)
          return null;

        var root = head;
        ListNode greater = null;

        var current = head;
        var stack = new Stack<ListNode>();

        while (current != null)
        {
          if (greater == null && current.val >= x)
          {
            greater = current;

            stack.Push(current);
            current = current.next;
            continue;
          }

          if (current.val < x)
          {
            if (greater == null)
            {
              stack.Push(current);
              current = current.next;
              continue;
            }

            var temp = current;
            var tempNext = current.next;

            while (temp.next != greater)
            {
              var prev = stack.Pop();
              prev.next = current.next;
              current.next = prev;

              if (stack.Count > 0)
              {
                stack.Peek().next = current;
              }
              else
              {
                root = current;
              }
            }

            while (current != tempNext)
            {
              stack.Push(current);
              current = current.next;
            }

            continue;
          }

          stack.Push(current);
          current = current.next;
        }

        return root;
      }
    }
  }
}
