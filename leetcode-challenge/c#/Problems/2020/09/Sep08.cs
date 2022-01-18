using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3453/
  ///    https://leetcode.com/submissions/detail/392722431/?from=/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3453/  
  /// </summary>
  internal class Sep08
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
      public int SumRootToLeaf(TreeNode root)
      {
        var sums = new List<string>();
        var sb = new StringBuilder();

        Grab(root, sums, sb);

        return sums.Select(ToNumber).Sum();
      }

      void Grab(TreeNode node, List<string> res, StringBuilder sb)
      {
        if (node == null)
          return;

        sb.Append(node.val.ToString());

        if (node.left == null && node.right == null)
          res.Add(sb.ToString());

        Grab(node.left, res, sb);
        Grab(node.right, res, sb);

        sb.Remove(sb.Length - 1, 1);
      }

      int ToNumber(string n)
      {
        var res = 0;

        for (var i = n.Length - 1; i >= 0; i--)
        {
          var ch = n[i];
          if (ch == '1')
            res += (int)Math.Pow(2, n.Length - 1 - i);
        }

        return res;
      }
    }
  }
}
