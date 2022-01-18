using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/560/week-2-october-8th-october-14th/3493/
  ///    https://leetcode.com/submissions/detail/408149016/?from=/explore/challenge/card/october-leetcoding-challenge/560/week-2-october-8th-october-14th/3493/
  /// </summary>
  internal class Oct13
  {
    /**/
    public class ListNode
    {
      public int val;
      public ListNode next;

      public ListNode(int val)
      {
        this.val = val;
      }
    }

    public class Solution
    {
      public ListNode SortList(ListNode head)
      {
        if (head == null)
          return head;

        var length = 0;
        var current = head;

        // initial length
        while (current != null)
        {
          length++;
          current = current.next;
        }

        var ans = GetSorted(head, length);
        return ans;
      }

      private ListNode GetSorted(ListNode head, int length)
      {
        if (length == 1)
          return new ListNode(head.val);

        if (length == 2)
        {
          var els = new int[] { head.val, head.next.val };
          Array.Sort(els);

          var node = new ListNode(els[0]);
          node.next = new ListNode(els[1]);
          return node;
        }

        var split = length / 2;

        var rightHead = head;
        for (int i = 0; i < split; i++)
          rightHead = rightHead.next;

        var left = GetSorted(head, split);
        var right = GetSorted(rightHead, length - split);

        var leftLength = split;
        var rightLength = length - split;

        var currentLeftIndex = 0;
        var currentRightIndex = 0;
        var currentLeftNode = left;
        var currentRightNode = right;

        var merged = new ListNode(int.MinValue);
        var mergedCurrent = merged;

        while (true)
        {
          if (currentLeftIndex == leftLength && currentRightIndex == rightLength)
            break;

          if (currentLeftIndex == leftLength)
          {
            mergedCurrent.next = new ListNode(currentRightNode.val);
            mergedCurrent = mergedCurrent.next;

            currentRightNode = currentRightNode.next;
            currentRightIndex++;
            continue;
          }

          if (currentRightIndex == rightLength)
          {
            mergedCurrent.next = new ListNode(currentLeftNode.val);
            mergedCurrent = mergedCurrent.next;

            currentLeftNode = currentLeftNode.next;
            currentLeftIndex++;
            continue;
          }

          if (currentLeftNode.val < currentRightNode.val)
          {
            mergedCurrent.next = new ListNode(currentLeftNode.val);
            mergedCurrent = mergedCurrent.next;

            currentLeftNode = currentLeftNode.next;
            currentLeftIndex++;
          }
          else
          {
            mergedCurrent.next = new ListNode(currentRightNode.val);
            mergedCurrent = mergedCurrent.next;

            currentRightNode = currentRightNode.next;
            currentRightIndex++;
          }
        }

        return merged.next;
      }
    }
  }
}
