namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/double-a-number-represented-as-a-linked-list/
///    Submission: https://leetcode.com/problems/double-a-number-represented-as-a-linked-list/submissions/1020276599/
/// </summary>
internal class P2816
{
  /**
   * Definition for singly-linked list.
   * public class ListNode {
   *     public int val;
   *     public ListNode next;
   *     public ListNode(int val=0, ListNode next=null) {
   *         this.val = val;
   *         this.next = next;
   *     }
   * }
   */
  public class Solution
  {
    public ListNode DoubleIt(ListNode head)
    {
      var stack = new Stack<ListNode>();

      while (head is not null)
      {
        stack.Push(head);
        head = head.next;
      }

      var carry = 0;

      while (stack.Count > 0)
      {
        var node = stack.Pop();
        var val = (node.val + node.val + carry);

        node.val = val % 10;
        carry = val >= 10 ? 1 : 0;

        head = node;
      }

      if (carry > 0)
      {
        var node = new ListNode(1);
        node.next = head;

        head = node;
      }

      return head;
    }
  }
}
