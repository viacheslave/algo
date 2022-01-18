using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3839/
  /// 
  /// </summary>
  internal class Aug07
  {
    // Definition for a Node.
    public class Node {
        public int val;
        public IList<Node> children;

        public Node(){}
        public Node(int _val,IList<Node> _children) {
            val = _val;
            children = _children;
      }
    }
    
    public class Solution
    {
      public IList<IList<int>> LevelOrder(Node root)
      {
        var res = new List<IList<int>>();

        CheckNode(res, root, 0);

        return res;
      }

      private void CheckNode(List<IList<int>> res, Node node, int depth)
      {
        if (node == null)
          return;

        if (res.Count == depth)
          res.Add(new List<int>());

        res[depth].Add(node.val);

        depth++;

        if (node.children != null)
          foreach (var n in node.children)
            CheckNode(res, n, depth);
      }
    }
  }
}
