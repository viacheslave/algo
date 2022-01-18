using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3660/
  /// 
  /// </summary>
  internal class Mar04
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
      public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
      {
        if (headA == null || headB == null)
          return null;

        var ac = headA;
        var ret = ac.next;

        while (ac != null)
        {
          ret = ac.next;
          ac.next = headB;

          var bCurrent = headB;
          while (bCurrent != null)
          {
            if (bCurrent == ac || bCurrent == ret)
            {
              ac.next = ret;
              return bCurrent;
            }

            bCurrent = bCurrent.next;

          }

          ac.next = ret;

          ac = ac.next;
        }

        return null;
      }
    }
  }
}
