namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/evaluate-boolean-binary-tree/
///    Submission: https://leetcode.com/submissions/detail/743503135/
/// </summary>
internal class P2331
{
  public class Solution
  {
    public bool EvaluateTree(TreeNode root)
    {
      return Ev(root);
    }

    private bool Ev(TreeNode node)
    {
      if (node.val == 1)
        return true;

      if (node.val == 0)
        return false;

      if (node.val == 2)
        return Ev(node.left) || Ev(node.right);

      return Ev(node.left) && Ev(node.right);
    }
  }
}
