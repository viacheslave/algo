using System.Collections.Generic;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3553/
  ///    https://leetcode.com/submissions/detail/426722371/?from=/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3553/
  /// </summary>
  internal class Dec03
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
      public TreeNode IncreasingBST(TreeNode root)
      {
        List<int> list = new List<int>();

        Traverse(root, list);

        var newRoot = new TreeNode(list[0]);
        var current = newRoot;

        for (var i = 1; i < list.Count; i++)
        {
          var newNode = new TreeNode(list[i]);
          current.right = newNode;
          current = current.right;
        }

        return newRoot;
      }

      private void Traverse(TreeNode node, List<int> list)
      {
        if (node == null)
          return;

        if (node.left != null)
          Traverse(node.left, list);

        list.Add(node.val);

        if (node.right != null)
          Traverse(node.right, list);
      }
    }
  }
}
