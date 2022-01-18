using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3524/
  ///    
  /// </summary>
  internal class Nov08
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
      public int full = 0;

      public int FindTilt(TreeNode root)
      {
        int sum = GetSum(root);
        return full;
      }

      private int GetSum(TreeNode node)
      {
        if (node == null)
          return 0;

        var left = GetSum(node.left);
        var right = GetSum(node.right);

        full += Math.Abs(left - right);

        return left + right + node.val;
      }
    }
  }
}
