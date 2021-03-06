namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/binary-tree-inorder-traversal/
///    Submission: https://leetcode.com/submissions/detail/228188288/
/// </summary>
internal class P0094
{
  public class Solution
  {
    public IList<int> InorderTraversal(TreeNode root)
    {
      var res = new List<int>();

      CheckNode(res, root);

      return res;
    }

    private void CheckNode(List<int> res, TreeNode node)
    {
      if (node == null)
        return;

      if (node.left != null)
        CheckNode(res, node.left);

      res.Add(node.val);

      if (node.right != null)
        CheckNode(res, node.right);
    }
  }
}
