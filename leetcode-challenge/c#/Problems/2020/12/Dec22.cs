using System;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/572/week-4-december-22nd-december-28th/3577/
  ///    https://leetcode.com/submissions/detail/433271901/?from=explore&item_id=3577
  /// </summary>
  internal class Dec22
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
      public bool IsBalanced(TreeNode root)
      {
        if (root == null)
          return true;

        try
        {
          GetDepth(root);
        }
        catch (Exception ex)
        {
          return false;
        }

        return true;
      }

      public int GetDepth(TreeNode node)
      {
        int left = 0, right = 0;

        if (node.left != null)
          left = GetDepth(node.left);

        if (node.right != null)
          right = GetDepth(node.right);

        if (Math.Abs(left - right) > 1)
          throw new Exception();

        return Math.Max(left, right) + 1;

      }
    }
  }
}
