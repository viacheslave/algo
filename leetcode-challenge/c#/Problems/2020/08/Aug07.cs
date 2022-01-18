using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3415/
  ///    https://leetcode.com/submissions/detail/377390104/?from=/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3415/
  /// </summary>
  internal class Aug07
  {
    /**
     * Definition for a binary tree node.
     */
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
      {
        this.val = val;
        this.left = left;
        this.right = right;
      }
    }

    public class Solution
    {
      public IList<IList<int>> VerticalTraversal(TreeNode root)
      {
        var sd = new SortedDictionary<int, List<(int value, int row)>>();
        Traverse(root, sd, 0, 0);

        return sd.Values
          .Select(list => (IList<int>)
            list
              .OrderBy(c => c.row)
              .ThenBy(c => c.value)
              .Select(c => c.value)
              .ToList())
          .ToList();
      }

      private void Traverse(TreeNode node, SortedDictionary<int, List<(int value, int row)>> sd, int col, int row)
      {
        if (node == null)
          return;

        if (!sd.ContainsKey(col))
          sd[col] = new List<(int, int)>();

        sd[col].Add((node.val, row));

        Traverse(node.left, sd, col - 1, row + 1);
        Traverse(node.right, sd, col + 1, row + 1);
      }
    }
  }
}
