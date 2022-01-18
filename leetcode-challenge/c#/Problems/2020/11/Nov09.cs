using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3525/
  ///    https://leetcode.com/submissions/detail/418396515/?from=/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3525/
  /// </summary>
  internal class Nov09
  {
    /**
      * Definition for a binary tree node. */
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    
    public class Solution
    {
      int _max = int.MinValue;

      public int MaxAncestorDiff(TreeNode root)
      {
        Traverse(root);

        return _max;
      }

      private (int, int) Traverse(TreeNode node)
      {
        var min = int.MaxValue;
        var max = int.MinValue;

        if (node.left != null)
        {
          var mm = Traverse(node.left);
          min = Math.Min(min, mm.Item1);
          max = Math.Max(max, mm.Item2);
        }

        if (node.right != null)
        {
          var mm = Traverse(node.right);
          min = Math.Min(min, mm.Item1);
          max = Math.Max(max, mm.Item2);
        }

        if (min != int.MaxValue)
          _max = Math.Max(_max, Math.Abs(node.val - min));

        if (max != int.MinValue)
          _max = Math.Max(_max, Math.Abs(node.val - max));

        return (Math.Min(node.val, min), Math.Max(node.val, max));
      }
    }
  }
}
