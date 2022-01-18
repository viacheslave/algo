using System;
using System.Collections.Generic;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/585/week-2-february-8th-february-14th/3635/
  ///    
  /// </summary>
  internal class Feb10
  {
    // Definition for a Node.
    public class Node
    {
      public int val;
      public Node next;
      public Node random;

      public Node() { }
      public Node(int _val)
      {
        val = _val;
      }
    }
    
    public class Solution
    {
      public Node CopyRandomList(Node head)
      {
        if (head == null)
          return null;

        var source = head;
        var target = new Node(source.val);
        var map = new Dictionary<Node, Node> { [source] = target };
        var result = target;

        while (source != null)
        {
          if (source.next != null)
          {
            var sourceNext = source.next;
            var targetNext = map.ContainsKey(sourceNext)
                ? map[sourceNext]
                : new Node(sourceNext.val);

            target.next = targetNext;
            map[sourceNext] = targetNext;
          }

          if (source.random != null)
          {
            var sourceRandom = source.random;
            var targetRandom = map.ContainsKey(sourceRandom)
                ? map[sourceRandom]
                : new Node(sourceRandom.val);

            target.random = targetRandom;
            map[sourceRandom] = targetRandom;
          }

          source = source.next;
          target = target.next;
        }

        return result;
      }
    }
  }
}
