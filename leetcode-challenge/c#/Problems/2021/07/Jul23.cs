using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/611/week-4-july-22nd-july-28th/3824/
  /// 
  /// </summary>
  internal class Jul23
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
      public TreeNode PruneTree(TreeNode root)
      {
        Traverse(root);

        if (root.val == 0 && root.left == null && root.right == null)
          return null;

        return root;
      }

      private void Traverse(TreeNode node)
      {
        if (node == null)
          return;

        Traverse(node.left);
        Traverse(node.right);

        if (node.left != null && node.left.val == 0 && (node.left.left == null && node.left.right == null))
          node.left = null;

        if (node.right != null && node.right.val == 0 && (node.right.left == null && node.right.right == null))
          node.right = null;
      }
    }
  }
}
