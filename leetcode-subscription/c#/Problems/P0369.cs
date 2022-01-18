using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/plus-one-linked-list/
  ///    Submission: https://leetcode.com/submissions/detail/452106279/
  ///    Google, Amazon
  /// </summary>
  internal class P0369
  {
    public class Solution
    {
      public ListNode PlusOne(ListNode head)
      {
        var stack = new Stack<ListNode>();

        var current = head;
        while (current != null)
        {
          stack.Push(current);
          current = current.next;
        }

        while (stack.Count > 0)
        {
          var node = stack.Pop();
          if (node.val < 9)
          {
            node.val++;
            return head;
          }

          node.val = 0;
        }

        var newHead = new ListNode(1);
        newHead.next = head;

        return newHead;
      }
    }
  }
}
