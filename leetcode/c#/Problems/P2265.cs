namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-nodes-equal-to-average-of-subtree/
///    Submission: https://leetcode.com/submissions/detail/695578721/
/// </summary>
internal class P2265
{
  public class Solution
  {
    public int AverageOfSubtree(TreeNode root)
    {
      return GetCount(root).ans;
    }

    private (int ans, (int sum, int count) stats) GetCount(TreeNode node)
    {
      if (node is null)
        return (default, default);

      var left = GetCount(node.left);
      var right = GetCount(node.right);

      var stats = (
        sum: left.stats.sum + right.stats.sum + node.val,
        count: left.stats.count + right.stats.count + 1);

      var avg = stats.count == 0
        ? node.val
        : (int)Math.Floor(1.0 * stats.sum / stats.count);

      var a = node.val == avg ? 1 : 0;
      return (ans: left.ans + right.ans + a, stats: stats);
    }
  }
}
