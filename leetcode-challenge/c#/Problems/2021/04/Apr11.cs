using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3704/
  /// 
  /// </summary>
  internal class Apr11
  {
    /**
      Definition for a binary tree node.
    */
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
      public int DeepestLeavesSum(TreeNode root)
      {
        var sl = new SortedDictionary<int, List<int>>();
        Traverse(root, 0, sl);

        var key = sl.Keys.Last();
        return sl[key].Sum();
      }

      private void Traverse(TreeNode node, int level, SortedDictionary<int, List<int>> sl)
      {
        if (node == null) return;
        if (!sl.ContainsKey(level)) sl[level] = new List<int>();
        sl[level].Add(node.val);
        Traverse(node.left, level + 1, sl);
        Traverse(node.right, level + 1, sl);
      }
    }
  }
}
