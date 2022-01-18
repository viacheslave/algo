using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/592/week-5-march-29th-march-31st/3689/
  ///   https://leetcode.com/submissions/detail/473787134/?from=explore&item_id=3689
  /// </summary>
  internal class Mar29
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
      private int _index;

      public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
      {
        try
        {
          var ans = new List<int>();
          Traverse(root, voyage, ans);

          return ans;
        }
        catch
        {
          return new[] { -1 }.ToList();
        }
      }

      private void Traverse(TreeNode node, int[] voyage, List<int> ans)
      {
        if (node == null)
          return;

        if (node.val != voyage[_index])
          throw new Exception();

        _index++;

        if (node.left == null && node.right == null)
          return;

        if (node.left != null && node.left.val == voyage[_index])
        {
          Traverse(node.left, voyage, ans);
          Traverse(node.right, voyage, ans);
          return;
        }

        if (node.left != null && node.left.val != voyage[_index])
        {
          // swap
          if (node.right != null && node.right.val == voyage[_index])
          {
            var tmp = node.left;
            node.left = node.right;
            node.right = tmp;

            ans.Add(node.val);

            Traverse(node.left, voyage, ans);
            Traverse(node.right, voyage, ans);
            return;
          }

          throw new Exception();
        }

        if (node.right != null && node.right.val == voyage[_index])
        {
          Traverse(node.left, voyage, ans);
          Traverse(node.right, voyage, ans);
          return;
        }

        throw new Exception();
      }
    }
  }
}
