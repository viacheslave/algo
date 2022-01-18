using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/607/week-5-june-29th-june-30th/3797/
  /// 
  /// </summary>
  internal class Jun30
  {
    /**
      Definition for a binary tree node.*/
      public class TreeNode {
          public int val;
          public TreeNode left;
          public TreeNode right;
          public TreeNode(int x) { val = x; }
      }
 
    public class Solution
    {
      public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
      {
        if (root == null)
          return null;

        var st1 = new List<TreeNode>();
        var st2 = new List<TreeNode>();

        Traverse(root, p, st1);
        Traverse(root, q, st2);

        int index = 0;
        while (index < st1.Count && index < st2.Count && st1[index] == st2[index])
        {
          index++;
          continue;
        }

        return st1[index - 1];
      }

      private bool Traverse(TreeNode node, TreeNode search, List<TreeNode> list)
      {
        if (node == null)
          return false;

        list.Add(node);

        if (node == search)
          return true;

        var left = Traverse(node.left, search, list);
        if (left) return true;

        var right = Traverse(node.right, search, list);
        if (right) return true;

        list.RemoveAt(list.Count - 1);

        return false;
      }
    }
  }
}
