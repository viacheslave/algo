using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3627/
  ///    https://leetcode.com/submissions/detail/453140114/?from=explore&item_id=3627
  /// </summary>
  internal class Feb03
  {
    /**
     * Definition for singly-linked list.*/
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) {
            val = x;
            next = null;
        }
    }
    
    public class Solution
    {
      public bool HasCycle(ListNode head)
      {
        if (head == null)
          return false;

        HashSet<ListNode> h = new HashSet<ListNode>();


        var current = head;
        h.Add(head);

        while (current.next != null)
        {
          if (h.Contains(current.next))
            return true;

          h.Add(current.next);
          current = current.next;
        }

        return false;
      }
    }
  }
}
