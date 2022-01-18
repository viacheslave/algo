using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  using Node = NodeChildren;

  /// <summary>
  ///    Problem: https://leetcode.com/problems/clone-n-ary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/458460417/
  ///    Amazon
  /// </summary>
  internal class P1490
  {
    /*
    // Definition for a Node.
    public class Node {
        public int val;
        public IList<Node> children;
    
        public Node() {
            val = 0;
            children = new List<Node>();
        }

        public Node(int _val) {
            val = _val;
            children = new List<Node>();
        }
    
        public Node(int _val, List<Node> _children) {
            val = _val;
            children = _children;
        }
    }
    */

    public class Solution
    {
      public Node CloneTree(Node root)
      {
        return Clone(root);
      }

      private Node Clone(Node node)
      {
        if (node == null)
          return null;

        var children = new List<Node>();
        foreach (var n in node.children)
        {
          var c = Clone(n);
          if (c != null)
            children.Add(c);
        }

        var copy = new Node(node.val, children);
        return copy;
      }
    }
  }
}
