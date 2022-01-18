using System.Collections.Generic;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3522/
  ///    
  /// </summary>
  internal class Nov07
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
      public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
      {
        var s1 = GetStack(l1);
        var s2 = GetStack(l2);

        ListNode current = null;

        var carry = 0;
        while (s1.Count > 0 || s2.Count > 0)
        {
          var val1 = s1.Count > 0 ? s1.Pop() : 0;
          var val2 = s2.Count > 0 ? s2.Pop() : 0;

          var node = new ListNode(val1 + val2 + carry);
          if (node.val >= 10)
          {
            node.val = node.val - 10;
            carry = 1;
          }
          else
          {
            carry = 0;
          }

          node.next = current;
          current = node;
        }

        if (carry == 1)
        {
          var node = new ListNode(carry);
          node.next = current;
          current = node;
        }

        return current;
      }

      Stack<int> GetStack(ListNode node)
      {
        var s = new Stack<int>();

        var current = node;
        if (current == null)
          return s;

        s.Push(current.val);

        while (current.next != null)
        {
          s.Push(current.next.val);
          current = current.next;
        }

        return s;
      }
    }
  }
}
