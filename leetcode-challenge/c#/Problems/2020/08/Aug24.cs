using System;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///	  https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/552/week-4-august-22nd-august-28th/3435/
  ///	  https://leetcode.com/submissions/detail/385736155/?from=/explore/challenge/card/august-leetcoding-challenge/552/week-4-august-22nd-august-28th/3435/
  /// </summary>
  internal class Aug24
  {
    /**
    /* Definition for a binary tree node. */
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
 
    public class Solution
    {
      public int SumOfLeftLeaves(TreeNode root)
      {
        return GetSum(0, root);
      }

      private int GetSum(int sum, TreeNode node)
      {
        if (node == null)
          return 0;

        var s = sum;
        if (node.left != null && node.left.left == null && node.left.right == null)
          s += node.left.val;

        s += GetSum(sum, node.left) + GetSum(sum, node.right);

        return s;
      }
    }
  }
}
