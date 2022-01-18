using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-tree-vertical-order-traversal/
  ///    Submission: https://leetcode.com/submissions/detail/452395094/
  ///    Facebook
  /// </summary>
  internal class P0314
  {
    public class Solution
    {
      public IList<IList<int>> VerticalOrder(TreeNode root)
      {
        var map = new Dictionary<TreeNode, (int col, int level, int value)>();

        Rec(root, 0, 0, map);

        return map.Values
          .OrderBy(x => x.col)
          .ThenBy(x => x.level)
          .GroupBy(x => x.col)
          .Select(x => (IList<int>)x.Select(_ => _.value).ToList())
          .ToList();
      }

      private void Rec(TreeNode node, int level, int col, Dictionary<TreeNode, (int col, int level, int value)> map)
      {
        if (node == null)
          return;

        map[node] = (col, level, node.val);

        Rec(node.left, level + 1, col - 1, map);
        Rec(node.right, level + 1, col + 1, map);
      }
    }
  }
}
