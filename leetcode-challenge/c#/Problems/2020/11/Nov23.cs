using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3541/
  ///    https://leetcode.com/submissions/detail/423241993/?from=/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3541/
  /// </summary>
  internal class Nov23
  {
    /**
     * Definition for a binary tree node.*/
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
      public int Rob(TreeNode root)
      {
        var dict = new Dictionary<(TreeNode, bool), int>();

        Rob(root, dict);

        var ans = Math.Max(
          dict[(root, true)],
          dict[(root, false)]);

        return ans;
      }

      private void Rob(TreeNode node, Dictionary<(TreeNode, bool), int> dict)
      {
        if (node == null)
        {
          dict[(node, true)] = 0;
          dict[(node, false)] = 0;
          return;
        }

        Rob(node.left, dict);
        Rob(node.right, dict);

        // if we take the house, all children should not be taken
        // sum all children and add current
        dict[(node, true)] =
          node.val +
          dict[(node.left, false)] +
          dict[(node.right, false)];

        var c1 = dict[(node.left, false)] + dict[(node.right, false)];
        var c2 = dict[(node.left, false)] + dict[(node.right, true)];
        var c3 = dict[(node.left, true)] + dict[(node.right, false)];
        var c4 = dict[(node.left, true)] + dict[(node.right, true)];

        // if we do not the house - all variants of children are possible
        // calc the max
        dict[(node, false)] =
          Math.Max(
            Math.Max(c1, c2),
            Math.Max(c3, c4)
          );
      }
    }
  }
}
