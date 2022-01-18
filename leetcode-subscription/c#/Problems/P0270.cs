using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/closest-binary-search-tree-value/
  ///    Submission: https://leetcode.com/submissions/detail/451605017/
  ///    All  
  /// </summary>
  internal class P0270
  {
    public class Solution
    {
      public int ClosestValue(TreeNode root, double target)
      {
        var node = root;

        var delta = Math.Abs(node.val - target);
        var ans = node.val;

        while (true)
        {
          if (node.val == target)
            return node.val;

          if (node.val > target && node.left != null)
          {
            node = node.left;

            if (Math.Abs(node.val - target) < delta)
            {
              delta = Math.Abs(node.val - target);
              ans = node.val;
            }

            continue;
          }

          if (node.val < target && node.right != null)
          {
            node = node.right;

            if (Math.Abs(node.val - target) < delta)
            {
              delta = Math.Abs(node.val - target);
              ans = node.val;
            }

            continue;
          }

          break;
        }

        return ans;
      }
    }
  }
}
