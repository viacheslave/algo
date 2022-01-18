namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/
///    Submission: https://leetcode.com/submissions/detail/615555706/
/// </summary>
internal class P2130
{
  public class Solution
  {
    public int PairSum(ListNode head)
    {
      var stack = new Stack<ListNode>();

      var current = head;
      var length = 0;

      while (current != null)
      {
        stack.Push(current);
        current = current.next;

        length++;
      }

      var ans = int.MinValue;
      current = head;

      for (var i = 0; i < length / 2; i++)
      {
        ans = Math.Max(ans, current.val + stack.Pop().val);
        current = current.next;
      }

      return ans;
    }
  }
}
