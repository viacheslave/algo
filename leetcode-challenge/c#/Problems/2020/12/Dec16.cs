using System.Collections.Generic;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3568/
  ///    https://leetcode.com/submissions/detail/431209021/?from=explore&item_id=3568
  /// </summary>
  internal class Dec16
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
      public bool IsValidBST(TreeNode root)
      {
        List<int> arr = new List<int>();

        return CheckNode(root, arr);
      }

      private bool CheckNode(TreeNode node, List<int> arr)
      {
        if (node == null)
          return true;

        if (node.left != null)
          if (!CheckNode(node.left, arr))
            return false;

        arr.Add(node.val);
        if (arr.Count > 1 && arr[arr.Count - 2] >= node.val)
          return false;

        if (node.right != null)
          if (!CheckNode(node.right, arr))
            return false;

        return true;
      }
    }
  }
}
