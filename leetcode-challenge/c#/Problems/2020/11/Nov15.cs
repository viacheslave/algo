using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3532/
  ///    https://leetcode.com/submissions/detail/420448640/?from=/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3532/
  /// </summary>
  internal class Nov15
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
      public int RangeSumBST(TreeNode root, int L, int R)
      {
        return Traverse(root, L, R);
      }

      int Traverse(TreeNode node, int L, int R)
      {
        if (node == null)
          return 0;

        var sum = 0;
        if (L <= node.val && node.val <= R)
        {
          sum += node.val;
        }

        sum += Traverse(node.left, L, R);
        sum += Traverse(node.right, L, R);
        return sum;
      }
    }
  }
}
