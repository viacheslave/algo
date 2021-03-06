namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/binary-search-tree-to-greater-sum-tree/
///    Submission: https://leetcode.com/submissions/detail/238850451/
/// </summary>
internal class P1038
{
  public class Solution
  {
    public TreeNode BstToGst(TreeNode root)
    {
      Convert(root, 0);

      return root;
    }

    private int Convert(TreeNode node, int sum)
    {
      if (node == null)
        return 0;

      var right = Convert(node.right, sum);

      var value = right + node.val;

      var left = Convert(node.left, value + sum);

      node.val = value + sum;

      return value + left;
    }
  }
}
