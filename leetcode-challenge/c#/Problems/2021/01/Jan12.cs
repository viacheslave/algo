namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3601/
  ///    https://leetcode.com/submissions/detail/441962714/?from=explore&item_id=3601
  /// </summary>
  internal class Jan12
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
        var left = l1;
        var right = l2;

        var currentNode = new ListNode(0);
        var head = currentNode;

        do
        {
          var newValue = (left == null ? 0 : left.val) + (right == null ? 0 : right.val);

          var newNode = new ListNode(newValue);

          if (left != null)
            left = left.next;

          if (right != null)
            right = right.next;

          if (currentNode.next == null)
            currentNode.next = newNode;
          else
            currentNode.next = new ListNode(1 + newValue);

          if (currentNode.next.val >= 10)
          {
            currentNode.next.val = currentNode.next.val % 10;
            currentNode.next.next = new ListNode(1);
          }

          currentNode = currentNode.next;
        }
        while (left != null || right != null);

        return head.next;
      }
    }
  }
}

