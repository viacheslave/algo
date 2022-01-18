namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3593/
  ///    https://leetcode.com/submissions/detail/438820485/?from=explore&item_id=3593
  /// </summary>
  internal class Jan05
  {
    /**
     Definition for singly-linked list.*/
     public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }
     
    public class Solution
    {
      public ListNode DeleteDuplicates(ListNode head)
      {
        if (head == null)
          return null;

        ListNode prevPointer = null;
        var current = head;
        var start = head;
        var end = head;
        var newHead = head;

        while (current != null)
        {
          var next = current.next;
          if (next == null)
          {
            if (start != end)
            {
              if (prevPointer != null)
                prevPointer.next = null;
              else
                newHead = null;
            }

            break;
          }

          if (current.val == next.val)
          {
            end = next;
          }
          else
          {
            if (start != end)
            {
              // remove duplicates
              if (prevPointer != null)
                prevPointer.next = next;
              else
                newHead = next;
            }
            else
            {
              prevPointer = current;
            }

            start = next;
            end = next;
          }

          current = current.next;
        }

        return newHead;
      }
    }
  }
}

