using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3509/
  ///    https://leetcode.com/submissions/detail/413684423/?from=/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3509/
  /// </summary>
  internal class Oct27
  {
    /**
    Definition for singly-linked list. */
    public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) {
          val = x;
          next = null;
      }
    }
    
    public class Solution
    {
      public ListNode DetectCycle(ListNode head)
      {

        if (head == null)
          return null;

        var map = new Dictionary<ListNode, int>();

        var node = head;

        for (var i = 0; ; i++)
        {
          if (node == null)
            return null;

          if (map.ContainsKey(node))
          {
            return node;
          }
          else
          {
            map.Add(node, i);
          }

          if (node.next != null)
          {
            node = node.next;
          }
          else
          {
            return null;
          }
        }
      }
    }
  }
}
