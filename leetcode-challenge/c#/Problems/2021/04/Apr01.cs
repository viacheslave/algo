using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3693/
  /// 
  /// </summary>
  internal class Apr01
  {
    /**
     Definition for singly-linked list.
    */
     public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }
 
    public class Solution
    {
      public bool IsPalindrome(ListNode head)
      {
        if (head == null)
          return true;

        if (head.next == null)
          return true;

        var stack = new Stack<ListNode>();
        var index = 0;

        var current = head;
        var mid = head;

        while (current != null)
        {
          index++;

          if (index % 2 == 0)
          {
            stack.Push(mid);
            mid = mid.next;
          }

          current = current.next;
        }

        var currentRight = index % 2 == 0 ? stack.Peek().next : stack.Peek().next.next;
        var currentLeft = stack.Pop();

        while (currentRight != null)
        {
          if (currentLeft.val != currentRight.val)
            return false;

          currentLeft = stack.Count > 0 ? stack.Pop() : null;
          currentRight = currentRight.next;
        }

        return true;
      }
    }
  }
}
