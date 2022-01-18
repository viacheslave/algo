using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/september-leetcoding-challenge-2021/636/week-1-september-1st-september-7th/3960/
  /// 
  /// </summary>
  internal class Sep02
  {
    /**
    /* Definition for a binary tree node.*/
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
      public IList<TreeNode> GenerateTrees(int n)
      {
        if (n == 0)
          return new List<TreeNode>();

        return Generate(1, n);
      }

      private IList<TreeNode> Generate(int left, int right)
      {
        if (right < left)
          return new List<TreeNode>() { new TreeNode(-1) };

        var nodes = new List<TreeNode>();

        for (var mid = left; mid <= right; mid++)
        {
          var leftNodes = Generate(left, mid - 1);
          var rightNodes = Generate(mid + 1, right);

          foreach (var l in leftNodes)
          {
            foreach (var r in rightNodes)
            {
              var root = new TreeNode(mid)
              {
                left = l.val == -1 ? null : l,
                right = r.val == -1 ? null : r
              };

              nodes.Add(root);
            }
          }
        }

        return nodes;
      }
    }
  }
}
