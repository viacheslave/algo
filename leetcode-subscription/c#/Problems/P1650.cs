using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/
  ///    Submission: https://leetcode.com/submissions/detail/462266832/
  ///    Facebook, Amazon
  /// </summary>
  internal class P1650
  {
    // Definition for a Node.
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
    }

    public class Solution
    {
      public Node LowestCommonAncestor(Node p, Node q)
      {
        var pmap = new Dictionary<Node, int>();
        var qmap = new Dictionary<Node, int>();

        var current = p;
        var index = 0;
        while (current != null)
        {
          pmap[current] = 0;
          index++;
          current = current.parent;
        }

        current = q;
        index = 0;
        while (current != null)
        {
          qmap[current] = 0;
          index++;
          current = current.parent;
        }

        var min = int.MaxValue;
        var ans = default(Node);

        foreach (var node in pmap)
        {
          if (qmap.ContainsKey(node.Key))
          {
            if (min > (pmap[node.Key] + qmap[node.Key]))
            {
              min = pmap[node.Key] + qmap[node.Key];
              ans = node.Key;
            }
          }
        }

        return ans;
      }
    }
  }
}
