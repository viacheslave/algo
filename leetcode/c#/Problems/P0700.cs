namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/search-in-a-binary-search-tree/
///    Submission: https://leetcode.com/submissions/detail/230893286/
/// </summary>
internal class P0700
{
  public class Solution
  {
    public TreeNode SearchBST(TreeNode root, int val)
    {
      if (root == null)
        return null;

      return Search(root, val);
    }

    TreeNode Search(TreeNode node, int val)
    {
      if (node == null)
        return null;

      if (val == node.val)
        return node;

      return Search(node.left, val) ?? Search(node.right, val);
    }
  }
}
