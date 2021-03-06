namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/binary-tree-preorder-traversal/
///    Submission: https://leetcode.com/submissions/detail/228188145/
/// </summary>
internal class P0144
{
  public class Solution
  {
    public IList<int> PreorderTraversal(TreeNode root)
    {
      var res = new List<int>();

      CheckNode(res, root);

      return res;


    }

    private void CheckNode(List<int> res, TreeNode node)
    {
      if (node == null)
        return;

      res.Add(node.val);

      if (node.left != null)
        CheckNode(res, node.left);

      if (node.right != null)
        CheckNode(res, node.right);
    }
  }
}
