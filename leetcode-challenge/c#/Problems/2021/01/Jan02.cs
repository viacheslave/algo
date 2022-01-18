namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3590/
  ///    https://leetcode.com/submissions/detail/437452634/?from=explore&item_id=3590
  /// </summary>
  internal class Jan02
  {
    /**
    Definition for a binary tree node. */
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    

    public class Solution
    {
      public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
      {
        return Search(cloned, target.val);
      }

      public TreeNode Search(TreeNode node, int value)
      {
        if (node == null)
          return null;

        if (node.val == value)
          return node;

        var left = Search(node.left, value);
        var right = Search(node.right, value);

        return left ?? right;
      }
    }
  }
}
