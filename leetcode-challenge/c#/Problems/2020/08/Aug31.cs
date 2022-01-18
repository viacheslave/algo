using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///	  https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/553/week-5-august-29th-august-31st/3443/
  ///	  https://leetcode.com/submissions/detail/388844246/?from=/explore/challenge/card/august-leetcoding-challenge/553/week-5-august-29th-august-31st/3443/
  /// </summary>
  internal class Aug31
  {
    /**
      * Definition for a binary tree node.*/
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
      {
        this.val = val;
        this.left = left;
        this.right = right;
      }
    }

    public class Solution
    {
      public TreeNode DeleteNode(TreeNode root, int key)
      {
        if (root == null)
          return null;

        if (key < root.val)
          root.left = DeleteNode(root.left, key);

        if (key > root.val)
          root.right = DeleteNode(root.right, key);

        if (key == root.val)
        {
          if (root.left == null)
            return root.right;

          if (root.right == null)
            return root.left;

          TreeNode current = root.right;
          TreeNode previous = null;

          while (current.left != null)
          {
            previous = current;
            current = current.left;
          }

          if (previous == null)
          {
            current.left = root.left;
            return current;
          }

          previous.left = current.right;
          current.right = root.right;
          current.left = root.left;

          return current;
        }

        return root;
      }
    }
  }
}
