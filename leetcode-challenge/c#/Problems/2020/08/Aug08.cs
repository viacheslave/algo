using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3417/
  ///    https://leetcode.com/submissions/detail/377804878/?from=/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3417/
  /// </summary>
  internal class Aug08
  {
    /**
     * Definition for a binary tree node.
     */
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
      {
        this.val = val;
        this.left = left;
        this.right = right;
      }
    }

    public class Solution
    {
      private int _ans = 0;

      public int PathSum(TreeNode root, int sum)
      {
        GetSums(root, sum);
        return _ans;
      }

      private List<int> GetSums(TreeNode node, int sum)
      {
        if (node == null)
          return new List<int>();

        var leftSums = GetSums(node.left, sum);
        var rightSums = GetSums(node.right, sum);

        var ret = new List<int>();
        ret.Add(node.val);

        if (node.val == sum)
          _ans++;

        foreach (var item in leftSums.Concat(rightSums))
        {
          if (node.val + item == sum)
            _ans++;

          ret.Add(node.val + item);
        }

        return ret;
      }
    }
  }
}
