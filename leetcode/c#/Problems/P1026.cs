namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/
///    Submission: https://leetcode.com/submissions/detail/239461102/
/// </summary>
internal class P1026
{
  public class Solution
  {
    int _max = int.MinValue;

    public int MaxAncestorDiff(TreeNode root)
    {
      Traverse(root);

      return _max;
    }

    private (int, int) Traverse(TreeNode node)
    {
      var min = int.MaxValue;
      var max = int.MinValue;

      if (node.left != null)
      {
        var mm = Traverse(node.left);
        min = Math.Min(min, mm.Item1);
        max = Math.Max(max, mm.Item2);
      }

      if (node.right != null)
      {
        var mm = Traverse(node.right);
        min = Math.Min(min, mm.Item1);
        max = Math.Max(max, mm.Item2);
      }

      if (min != int.MaxValue)
        _max = Math.Max(_max, Math.Abs(node.val - min));

      if (max != int.MinValue)
        _max = Math.Max(_max, Math.Abs(node.val - max));

      return (Math.Min(node.val, min), Math.Max(node.val, max));
    }
  }
}
