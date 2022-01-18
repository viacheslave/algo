using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-distance-in-a-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/451549838/
  ///    Google
  /// </summary>
  internal class P1740
  {
    public class Solution
    {
      public int FindDistance(TreeNode root, int p, int q)
      {
        var nodes = new Dictionary<int, TreeNode>();

        Rec(root, null, nodes);

        var p_parents = new List<int>();
        var current = p;

        while (true)
        {
          p_parents.Add(current);

          var parent = nodes[current];
          if (parent != null)
            current = parent.val;
          else
            break;
        }

        var q_parents = new List<int>();
        current = q;

        while (true)
        {
          q_parents.Add(current);

          var parent = nodes[current];
          if (parent != null)
            current = parent.val;
          else
            break;
        }

        if (p_parents.Contains(q))
          return p_parents.IndexOf(q);

        if (q_parents.Contains(p))
          return q_parents.IndexOf(p);

        var ans = int.MaxValue;

        for (var i = 0; i < p_parents.Count; i++)
        {
          var value = p_parents[i];
          if (q_parents.Contains(value))
            ans = Math.Min(ans, i + q_parents.IndexOf(value));
        }

        return ans;
      }

      private void Rec(TreeNode node, TreeNode root, Dictionary<int, TreeNode> nodes)
      {
        if (node == null)
          return;

        nodes[node.val] = root;
        Rec(node.left, node, nodes);
        Rec(node.right, node, nodes);
      }
    }
  }
}
