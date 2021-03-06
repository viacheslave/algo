namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/insert-into-a-binary-search-tree
///    Submission: https://leetcode.com/submissions/detail/230893886/
/// </summary>
internal class P0701
{
  public class Solution
  {
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
      if (root == null)
        return new TreeNode(val);

      Insert(root, val);

      return root;
    }

    void Insert(TreeNode node, int val)
    {
      if (val < node.val)
      {
        if (node.left == null)
          node.left = new TreeNode(val);
        else
          Insert(node.left, val);
      }

      if (val > node.val)
      {
        if (node.right == null)
          node.right = new TreeNode(val);
        else
          Insert(node.right, val);
      }
    }
  }
}
