using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/615/week-3-august-15th-august-21st/3903/
  /// 
  /// </summary>
  internal class Aug19
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
      public int MaxProduct(TreeNode root)
      {
        var list = new List<int>();
        var sum = GetSum(root, list);

        var ans = 0L;
        foreach (var item in list)
        {
          var value = Math.BigMul(item, sum - item);
          if (value > ans)
            ans = value;
        }

        return Convert.ToInt32(ans % 1000000007);
      }

      private int GetSum(TreeNode node, List<int> list)
      {
        if (node == null) return 0;
        var sum = node.val + GetSum(node.left, list) + GetSum(node.right, list);
        list.Add(sum);
        return sum;
      }
    }
  }
}
