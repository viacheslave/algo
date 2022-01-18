using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3485/
  ///    https://leetcode.com/submissions/detail/405176680/?from=/explore/challenge/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3485/
  /// </summary>
  internal class Oct06
  {
    /**
     * Definition for a binary tree node.
     */

    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
      public TreeNode InsertIntoBST(TreeNode root, int val)
      {
        if (root == null)
          return new TreeNode(val);

        Insert(root, val);

        return root;
      }

      void Insert(TreeNode node, int val)
      {
        if (val < node.val)
        {
          if (node.left == null)
            node.left = new TreeNode(val);
          else
            Insert(node.left, val);
        }

        if (val > node.val)
        {
          if (node.right == null)
            node.right = new TreeNode(val);
          else
            Insert(node.right, val);
        }
      }
    }
  }
}
