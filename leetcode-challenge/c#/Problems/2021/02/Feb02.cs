namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3626/
  ///    https://leetcode.com/submissions/detail/453139909/?from=explore&item_id=3626
  /// </summary>
  internal class Feb02
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
      TreeNode _root;

      public TreeNode TrimBST(TreeNode root, int L, int R)
      {
        if (root == null)
          return null;

        _root = root;
        Trim(root, L, R);

        return _root;
      }

      void Trim(TreeNode node, int L, int R)
      {
        if (node == null)
          return;

        if (node.val < L)
        {
          _root = node.right;
          Trim(node.right, L, R);
          return;
        }

        if (node.val > R)
        {
          _root = node.left;
          Trim(node.left, L, R);
          return;
        }

        if (node.left != null)
        {
          if (node.left.val < L)
          {
            node.left = node.left.right;
            Trim(node, L, R);
          }
          else
            Trim(node.left, L, R);
        }

        if (node.right != null)
        {
          if (node.right.val > R)
          {
            node.right = node.right.left;
            Trim(node, L, R);
          }
          else
            Trim(node.right, L, R);
        }
      }
    }
  }
}
