namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/path-sum-iii/
///    Submission: https://leetcode.com/submissions/detail/238328597/
/// </summary>
internal class P0437
{
  public class Solution
  {
    int _count;

    public int PathSum(TreeNode root, int sum)
    {
      if (root == null)
        return 0;

      var queue = new Queue<TreeNode>();
      queue.Enqueue(root);

      while (queue.Count > 0)
      {
        var node = queue.Dequeue();
        if (node == null)
          continue;

        Traverse(node, 0, sum);

        queue.Enqueue(node.left);
        queue.Enqueue(node.right);
      }

      return _count;
    }

    private void Traverse(TreeNode node, int curretnSum, int target)
    {
      if (node == null)
        return;

      if (curretnSum + node.val == target)
        _count++;

      Traverse(node.left, curretnSum + node.val, target);
      Traverse(node.right, curretnSum + node.val, target);
    }
  }
}
