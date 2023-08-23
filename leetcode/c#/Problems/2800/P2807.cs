namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/insert-greatest-common-divisors-in-linked-list/
///    Submission: https://leetcode.com/problems/insert-greatest-common-divisors-in-linked-list/submissions/1027998924/
/// </summary>
internal class P2807
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
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
      var cur = head;

      while (cur.next is not null)
      {
        var ins = new ListNode(GetGcd(cur.val, cur.next.val));
        ins.next = cur.next;
        cur.next = ins;

        cur = ins.next;
      }

      return head;
    }

    private int GetGcd(int a, int b)
    {
      if (a % b == 0)
        return b;

      if (b % a == 0)
        return a;

      if (a == b)
        return a;

      return a > b
        ? GetGcd((a - b) % b, b)
        : GetGcd(a, (b - a) % a);
    }
  }
}
