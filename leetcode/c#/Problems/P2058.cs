namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points/
///    Submission: https://leetcode.com/submissions/detail/581931008/
/// </summary>
internal class P2058
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
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
      var indices = new List<int>();

      var index = 1;
      var prev = head;
      var current = head.next;

      while (current != null)
      {
        if (current.next == null)
          break;

        if (prev.val < current.val && current.val > current.next.val)
          indices.Add(index);

        if (prev.val > current.val && current.val < current.next.val)
          indices.Add(index);

        index++;
        prev = current;
        current = current.next;
      }

      if (indices.Count < 2)
        return new int[] { -1, -1 };

      // find minimum
      var min = int.MaxValue;
      for (var i = 1; i < indices.Count; i++)
        min = Math.Min(min, indices[i] - indices[i - 1]);

      return new int[] { min, indices[indices.Count - 1] - indices[0] };
    }
  }
}
