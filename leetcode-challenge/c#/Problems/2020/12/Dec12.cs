using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3563/
  ///    https://leetcode.com/submissions/detail/429850374/?from=explore&item_id=3563
  /// </summary>
  internal class Dec12
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
      private TreeNode _subTree = null;

      public TreeNode SubtreeWithAllDeepest(TreeNode root)
      {
        var nodes = new List<(TreeNode, int)>();
        TraverseDepths(0, root, nodes);

        var maxDepth = nodes.Max(x => x.Item2);
        var maxDepthNodes = nodes.Where(x => x.Item2 == maxDepth).Select(x => x.Item1).Select(x => x.val).ToHashSet();

        TraverseNodes(root, maxDepthNodes);

        return _subTree;
      }

      private List<int> TraverseNodes(TreeNode node, HashSet<int> maxDepthNodes)
      {
        if (node == null)
          return new List<int>();

        if (_subTree != null)
          return new List<int>();

        var left = TraverseNodes(node.left, maxDepthNodes);
        var right = TraverseNodes(node.right, maxDepthNodes);

        var all = new List<int>();
        all.AddRange(left);
        all.AddRange(right);
        all.Add(node.val);

        if (maxDepthNodes.IsSubsetOf(all) && _subTree == null)
        {
          _subTree = node;
          return all;
        }


        return all;
      }

      private void TraverseDepths(int depth, TreeNode node, List<(TreeNode, int)> nodes)
      {
        if (node == null)
          return;

        nodes.Add((node, depth));

        TraverseDepths(depth + 1, node.left, nodes);
        TraverseDepths(depth + 1, node.right, nodes);
      }
    }
  }
}
