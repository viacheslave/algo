using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3666/
  /// 
  /// </summary>
  internal class Mar09
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
      public TreeNode AddOneRow(TreeNode root, int v, int d)
      {
        if (root == null)
          return null;

        if (d == 1)
        {
          var n = new TreeNode(v);
          n.left = root;
          return n;
        }

        Traverse(root, v, d, 1);
        return root;
      }

      private void Traverse(TreeNode node, int v, int d, int depth)
      {
        if (node == null)
          return;

        if (depth == d - 1)
        {
          var n = new TreeNode(v);
          n.left = node.left;
          node.left = n;

          n = new TreeNode(v);
          n.right = node.right;
          node.right = n;

          return;
        }

        Traverse(node.left, v, d, depth + 1);
        Traverse(node.right, v, d, depth + 1);
      }
    }
  }
}
