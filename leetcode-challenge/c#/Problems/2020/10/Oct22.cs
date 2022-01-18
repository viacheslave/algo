using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3504/
  ///    https://leetcode.com/submissions/detail/411783809/?from=/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3504/
  /// </summary>
  internal class Oct22
  {
    /**
     * Definition for a binary tree node.
     */
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
     
    public class Solution
    {
      public int MinDepth(TreeNode root)
      {
        if (root == null)
          return 0;

        int min = CheckNode(root, 1, 0);

        return min;
      }

      private int CheckNode(TreeNode node, int min, int depth)
      {
        if (node == null)
          return depth;

        depth++;

        if (node.left == null && node.right == null)
        {
          return depth;
        }

        if (node.left != null && node.right != null)
          return Math.Min(
            CheckNode(node.left, min, depth),
            CheckNode(node.right, min, depth)
          );

        if (node.left != null)
          return CheckNode(node.left, min, depth);

        if (node.right != null)
          return CheckNode(node.right, min, depth);

        return depth;
      }
    }
  }
}
