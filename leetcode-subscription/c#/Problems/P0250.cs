using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-univalue-subtrees/
  ///    Submission: https://leetcode.com/submissions/detail/452376466/
  ///    Google, eBay
  /// </summary>
  internal class P0250
  {
    public class Solution
    {
      public int CountUnivalSubtrees(TreeNode root)
      {
        return Rec(root).count;
      }

      public (int? value, int count) Rec(TreeNode node)
      {
        if (node == null)
          return (null, 0);

        var left = Rec(node.left);
        var right = Rec(node.right);

        var count = left.count + right.count;
        int? value = null;

        if (node.left == null && node.right == null)
        {
          value = node.val;
          count += 1;
        }
        else if (node.left == null && node.right != null)
        {
          if (right.value == node.val)
          {
            value = node.val;
            count += 1;
          }
        }
        else if (node.left != null && node.right == null)
        {
          if (left.value == node.val)
          {
            value = node.val;
            count += 1;
          }
        }
        else
        {
          if (left.value == node.val && right.value == node.val)
          {
            value = node.val;
            count += 1;
          }
        }

        return (value, count);
      }
    }
  }
}
