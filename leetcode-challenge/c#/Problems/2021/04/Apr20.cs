using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3714/
  /// 
  /// </summary>
  internal class Apr20
  {
    /*
    // Definition for a Node.*/
    public class Node {
      public int val;
      public IList<Node> children;

      public Node(){}
      public Node(int _val, IList<Node> _children)
      {
        val = _val;
        children = _children;
      }
    }
    
    public class Solution
    {
      public IList<int> Preorder(Node root)
      {

        var res = new List<int>();

        CheckNode(res, root, 0);

        return res;
      }

      private void CheckNode(List<int> res, Node node, int depth)
      {
        if (node == null)
          return;

        res.Add(node.val);

        depth++;

        if (node.children != null)
          foreach (var n in node.children)
            CheckNode(res, n, depth);
      }
    }
  }
}
