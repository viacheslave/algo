namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/odd-even-linked-list/
///    Submission: https://leetcode.com/submissions/detail/243310169/
/// </summary>
internal class P0328
{
  public class Solution
  {
    public ListNode OddEvenList(ListNode head)
    {
      if (head == null)
        return null;

      var pos = 2;
      ListNode prev = head;
      ListNode current = head.next;
      ListNode lastOdd = head;

      while (current != null)
      {
        if (pos % 2 == 0)
        {
          prev = current;
          current = current.next;
          pos++;

          continue;
        }

        prev.next = current.next;
        current.next = lastOdd.next;
        lastOdd.next = current;
        lastOdd = current;

        current = prev.next;
        pos++;
      }

      return head;
    }
  }
}
