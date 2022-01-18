using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3529/
  ///    https://leetcode.com/submissions/detail/419840011/?from=/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3529/
  /// </summary>
  internal class Nov13
  {
    /*
    // Definition for a Node.*/
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node(){}
        public Node(int _val,Node _left,Node _right,Node _next) {
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
        var reff = new Dictionary<int, Node>();

        Traverse(root, reff, 0);

        return root;
      }

      private void Traverse(Node node, Dictionary<int, Node> reff, int index)
      {
        if (node == null)
          return;

        Traverse(node.right, reff, index + 1);

        if (reff.ContainsKey(index))
          node.next = reff[index];

        reff[index] = node;

        Traverse(node.left, reff, index + 1);
      }
    }
  }
}
