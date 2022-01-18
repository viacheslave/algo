using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/615/week-3-august-15th-august-21st/3899/
  /// 
  /// </summary>
  internal class Aug17
  {
    /**
     * Definition for a binary tree node.*/
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
     
    public class Solution
    {
      public int GoodNodes(TreeNode root)
      {
        var list = new List<int>();
        var max = int.MinValue;

        return Traverse(root, list, max);
      }

      private int Traverse(TreeNode node, List<int> list, int max)
      {
        if (node == null)
          return 0;

        //list.Add(node.val);

        var val =
          Traverse(node.left, list, Math.Max(max, node.val)) +
          Traverse(node.right, list, Math.Max(max, node.val));

        if (node.val >= max)
          val++;

        //list.Remove(list.Count - 1);
        return val;
      }
    }
  }
}
