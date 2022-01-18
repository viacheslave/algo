namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/reverse-nodes-in-even-length-groups/
///    Submission: https://leetcode.com/submissions/detail/587075601/
/// </summary>
internal class P2074
{
  public class Solution
  {
    public ListNode ReverseEvenLengthGroups(ListNode head)
    {
      var index = 1;
      var curr = head;
      var prev = default(ListNode);

      for (var group = 1; ; group++)
      {
        if (curr == null)
          break;

        var (from, to) = (
          from: group * (group + 1) / 2 - group + 1,
          to: group * (group + 1) / 2);

        var stack = new Stack<ListNode>();

        var prevGroupEnd = prev;

        while (curr != null)
        {
          if (from <= index && index <= to)
          {
            stack.Push(curr);
            prev = curr;
            curr = curr.next;
            index++;
            continue;
          }
          break;
        }

        var nextGroupStart = curr;

        if (stack.Count % 2 == 0)
        {
          var chainHead = stack.Pop();
          var chainCurrent = chainHead;

          while (stack.Count > 0)
          {
            chainCurrent.next = stack.Pop();

            if (chainCurrent.next != null)
              chainCurrent = chainCurrent.next;
          }

          prevGroupEnd.next = chainHead;
          chainCurrent.next = nextGroupStart;

          prev = chainCurrent;
          curr = nextGroupStart;
        }
      }

      return head;
    }
  }
}
