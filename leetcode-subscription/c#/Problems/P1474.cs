using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/delete-n-nodes-after-m-nodes-of-a-linked-list/
  ///    Submission: https://leetcode.com/submissions/detail/451212562/
  ///    Microsoft
  /// </summary>
  internal class P1474
  {
    public class Solution
    {
      public ListNode DeleteNodes(ListNode head, int m, int n)
      {
        var current = head;

        while (current != null)
        {
          for (var i = 0; i < m - 1; i++)
          {
            current = current.next;
            if (current == null)
              return head;
          }

          for (var i = 0; i < n; i++)
          {
            if (current.next == null)
              return head;

            current.next = current.next.next;
          }

          current = current.next;
        }

        return head;
      }
    }
  }
}
