using System;
using System.Collections.Generic;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/585/week-2-february-8th-february-14th/3634/
  ///    
  /// </summary>
  internal class Feb09
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
      public TreeNode ConvertBST(TreeNode root)
      {
        Convert(root, 0);

        return root;
      }

      private int Convert(TreeNode node, int sum)
      {
        if (node == null)
          return 0;

        var right = Convert(node.right, sum);

        var value = right + node.val;

        var left = Convert(node.left, value + sum);

        node.val = value + sum;

        return value + left;
      }
    }
  }
}
