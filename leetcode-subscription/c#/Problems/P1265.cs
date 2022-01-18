using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/print-immutable-linked-list-in-reverse/
  ///    Submission: https://leetcode.com/submissions/detail/459803969/
  ///    Google, Facebook
  /// </summary>
  internal class P1265
  {
    public abstract class ImmutableListNode
    {
      public abstract void PrintValue(); // print the value of this node.
      public abstract ImmutableListNode GetNext(); // return the next node.
    }

    public class Solution
    {
      public void PrintLinkedListInReverse(ImmutableListNode head)
      {
        Print(head);
      }

      private void Print(ImmutableListNode node)
      {
        if (node != null)
        {
          Print(node.GetNext());
          node.PrintValue();
        }
      }
    }
  }
}
