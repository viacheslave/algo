using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/inorder-successor-in-bst-ii/
  ///    Submission: https://leetcode.com/submissions/detail/454490758/
  ///    Microsoft
  /// </summary>
  internal class P0510
  {
    public class Node
    {
      public int val;
      public Node left;
      public Node right;
      public Node parent;
    }

    public class Solution
    {
      public Node InorderSuccessor(Node x)
      {
        var root = x;
        while (root.parent != null)
          root = root.parent;

        var list = new LinkedList<Node>();

        Rec(root, list);

        var current = list.First;
        while (current.Value != x)
          current = current.Next;

        return current.Next?.Value ?? default;
      }

      private void Rec(Node node, LinkedList<Node> list)
      {
        if (node == null)
          return;

        Rec(node.left, list);

        list.AddLast(node);

        Rec(node.right, list);
      }
    }
  }
}
