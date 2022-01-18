using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/599/week-2-may-8th-may-14th/3742/
  /// 
  /// </summary>
  internal class May14
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
      TreeNode anc;

      public void Flatten(TreeNode root)
      {
        if (root == null)
          return;

        Fl(root);

        var current = root;

        //current.right = current.left;

        while (current.left != null)
        {
          current.right = current.left;
          current.left = null;

          current = current.right;
        }
      }

      private void Fl(TreeNode node)
      {
        if (node == null)
          return;

        anc = node;

        if (node.left == null && node.right == null)
          return;

        Fl(node.left);

        anc.left = node.right;

        Fl(node.right);
      }
    }
  }
}
