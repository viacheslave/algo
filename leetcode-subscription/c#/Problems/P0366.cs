using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-leaves-of-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/452714615/
  ///    LinkedIn
  /// </summary>
  internal class P0366
  {
    public class Solution
    {
      public IList<IList<int>> FindLeaves(TreeNode root)
      {
        var map = new Dictionary<TreeNode, TreeNode>();

        Rec(root, null, map);

        var leaves = map
          .Where(x => x.Key.left == null && x.Key.right == null)
          .Select(x => x.Key).ToList();

        var ans = new List<IList<int>>();

        while (leaves.Count > 0)
        {
          var next = new List<TreeNode>();

          foreach (var item in leaves)
          {
            var parent = map[item];
            if (parent == null)
              continue;

            if (parent.left == item)
              parent.left = null;

            if (parent.right == item)
              parent.right = null;

            if (parent.left == null && parent.right == null)
              next.Add(parent);
          }

          ans.Add(leaves.Select(x => x.val).ToList());

          leaves = next;
        }

        return ans;
      }

      private void Rec(TreeNode node, TreeNode parent, Dictionary<TreeNode, TreeNode> map)
      {
        if (node == null)
          return;

        map[node] = parent;

        Rec(node.left, node, map);
        Rec(node.right, node, map);
      }
    }
  }
}
