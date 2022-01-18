using System.Collections.Generic;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3556/
  ///    https://leetcode.com/submissions/detail/427775715/?from=explore&item_id=3556
  /// </summary>
  internal class Dec06
  {
    /*
    // Definition for a Node.*/
    public class Node {
      public int val;
      public Node left;
      public Node right;
      public Node next;

      public Node(){}
      public Node(int _val, Node _left, Node _right, Node _next)
      {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
      }
    }
    
    public class Solution
    {
      public Node Connect(Node root)
      {
        if (root == null)
          return null;

        Process(root, new Stack<Node>());

        return root;
      }

      private void Process(Node node, Stack<Node> stack)
      {
        if (stack.Count > 0)
        {
          node.next = stack.Pop();
        }

        if (node.right != null)
          Process(node.right, stack);

        if (node.left != null)
          Process(node.left, stack);

        stack.Push(node);
      }
    }
  }
}
