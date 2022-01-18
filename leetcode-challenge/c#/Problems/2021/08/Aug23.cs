using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/616/week-4-august-22nd-august-28th/3908/
  /// 
  /// </summary>
  internal class Aug23
  {
    /**
     * Definition for a binary tree node.*/
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    
    public class Solution
    {
      public bool FindTarget(TreeNode root, int k)
      {
        if (root == null)
          return false;

        return Pick(root, root, k);
      }

      private bool Pick(TreeNode root, TreeNode node, int k)
      {
        if (node == null)
          return false;

        return Search(root, node, k)
          || Pick(root, node.left, k)
          || Pick(root, node.right, k);
      }

      private bool Search(TreeNode searchNode, TreeNode node, int k)
      {
        if (searchNode == null || searchNode == node)
          return false;

        return searchNode.val + node.val == k
          || Search(searchNode.left, node, k)
          || Search(searchNode.right, node, k);
      }
    }
  }
}
