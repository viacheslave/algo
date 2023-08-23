namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/remove-nodes-from-linked-list/
///    Submission: https://leetcode.com/problems/remove-nodes-from-linked-list/submissions/850594637/
/// </summary>
internal class P2487
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
    public ListNode RemoveNodes(ListNode head)
    {
      // monotonous stack -like

      var stack = new Stack<ListNode>();

      var current = head;
      stack.Push(current);

      while (current.next is not null)
      {
        var node = current.next;

        while (stack.Count > 0 && node.val > stack.Peek().val)
        {
          stack.Pop();
          if (stack.Count > 0)
          {
            stack.Peek().next = node;
          }
        }

        stack.Push(node);
        current = current.next;
      }

      current = null;
      while (stack.Count > 0)
      {
        current = stack.Pop();
      }

      return current;
    }
  }
}
