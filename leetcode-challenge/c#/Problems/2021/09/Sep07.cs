using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/636/week-1-september-1st-september-7th/3966/
  /// 
  /// </summary>
  internal class Sep07
  {
   /*
   * Definition for singly-linked list.*/
    public class ListNode
    {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
    }

    public class Solution
    {
      ListNode headNew = null;

      public ListNode ReverseList(ListNode head)
      {
        if (head == null)
          return head;

        var node = GetNext(head);
        node.next = null;
        return headNew;
      }

      private ListNode GetNext(ListNode node)
      {
        if (node.next == null)
        {
          headNew = node;
          return headNew;
        }

        var nextNode = GetNext(node.next);
        nextNode.next = node;
        return node;
      }
    }
  }
}
