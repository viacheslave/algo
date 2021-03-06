namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/linked-list-cycle/
///    Submission: https://leetcode.com/submissions/detail/226904418/
/// </summary>
internal class P0141
{
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
