using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3551/
  ///    https://leetcode.com/submissions/detail/426007722/?from=/explore/featured/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3551/
  /// </summary>
  internal class Dec01
  {
    /**
    * Definition for a binary tree node.*/
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
      public int MaxDepth(TreeNode root)
      {
        int d = 1;
        return GetMaxDepth(root, 1);
      }

      private int GetMaxDepth(TreeNode node, int d)
      {
        if (node == null)
          return 0;

        if (node.left == null && node.right == null)
          return 1;

        var left = 0;
        var right = 0;

        if (node.left != null)
          left = GetMaxDepth(node.left, d);
        if (node.right != null)
          right = GetMaxDepth(node.right, d);

        if (left > right)
          return d + left;
        if (left < right)
          return d + right;
        return d + left;
      }
    }
  }
}
