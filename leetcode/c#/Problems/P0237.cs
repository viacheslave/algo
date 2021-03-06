namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/delete-node-in-a-linked-list/
///    Submission: https://leetcode.com/submissions/detail/227378463/
/// </summary>
internal class P0237
{
  public class Solution
  {
    public void DeleteNode(ListNode node)
    {
      var current = node;

      while (current.next != null)
      {
        current.val = current.next.val;

        if (current.next != null && current.next.next == null)
        {
          current.next = null;
        }
        else
        {
          current = current.next;
        }
      }

      current.next = null;
    }
  }
}
