using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-ii/
  ///    Submission: https://leetcode.com/submissions/detail/462268349/
  ///    Microsoft, Amazon
  /// </summary>
  internal class P1644
  {
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
    public class Solution
    {
      public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
      {
        var parents = new Dictionary<TreeNode, TreeNode>();
        Rec(root, null, parents);

        if (!parents.ContainsKey(p) || !parents.ContainsKey(q))
          return null;

        var pmap = new Dictionary<TreeNode, int>();
        var qmap = new Dictionary<TreeNode, int>();

        var current = p;
        var index = 0;
        while (current != null)
        {
          pmap[current] = 0;
          index++;
          current = parents[current];
        }

        current = q;
        index = 0;
        while (current != null)
        {
          qmap[current] = 0;
          index++;
          current = parents[current];
        }

        var min = int.MaxValue;
        var ans = default(TreeNode);

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

      private void Rec(TreeNode node, TreeNode parent, Dictionary<TreeNode, TreeNode> parents)
      {
        if (node == null)
          return;

        parents[node] = parent;
        Rec(node.left, node, parents);
        Rec(node.right, node, parents);
      }
    }
  }
}
