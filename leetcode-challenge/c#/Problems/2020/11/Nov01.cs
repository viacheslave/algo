using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3516/
  ///    https://leetcode.com/submissions/detail/415511883/?from=/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3516/
  /// </summary>
  internal class Nov01
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
      public int GetDecimalValue(ListNode head)
      {
        var ans = 0;

        var current = head;
        while (current != null)
        {
          ans *= 2;
          ans += current.val;
          current = current.next;
        }

        return ans;
      }
    }
  }
}
