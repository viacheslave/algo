using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/600/week-3-may-15th-may-21st/3749/
  /// 
  /// </summary>
  internal class May20
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
      public IList<IList<int>> LevelOrder(TreeNode root)
      {
        var res = new List<IList<int>>();

        CheckNode(res, root, 0);

        return res;
      }

      private void CheckNode(List<IList<int>> res, TreeNode node, int depth)
      {
        if (node == null)
          return;

        if (res.Count == depth)
          res.Add(new List<int>());

        res[depth].Add(node.val);

        depth++;

        if (node.left != null)
          CheckNode(res, node.left, depth);

        if (node.right != null)
          CheckNode(res, node.right, depth);
      }
    }
  }
}
