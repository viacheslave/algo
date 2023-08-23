namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/root-equals-sum-of-children/
///    Submission: https://leetcode.com/submissions/detail/678431015/
/// </summary>
internal class P2236
{
  public class Solution
  {
    public bool CheckTree(TreeNode root)
    {
      return root.val == root.left.val + root.right.val;
    }
  }
}
