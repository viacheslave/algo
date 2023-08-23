namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/kth-largest-sum-in-a-binary-tree/
///    Submission: https://leetcode.com/problems/kth-largest-sum-in-a-binary-tree/submissions/909458599/
/// </summary>
internal class P2583
{
  /**
   * Definition for a binary tree node.
   * public class TreeNode {
   *     public int val;
   *     public TreeNode left;
   *     public TreeNode right;
   *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
   *         this.val = val;
   *         this.left = left;
   *         this.right = right;
   *     }
   * }
   */
  public class Solution
  {
    public long KthLargestLevelSum(TreeNode root, int k)
    {
      var sums = new List<long>();

      DFS(root, 0, sums);

      if (sums.Count < k)
        return -1;

      return sums.OrderByDescending(d => d).Skip(k - 1).First();
    }

    private void DFS(TreeNode node, int level, List<long> sums)
    {
      if (node is null)
        return;

      if (sums.Count < level + 1)
        sums.Add(0);

      sums[level] += node.val;

      DFS(node.left, level + 1, sums);
      DFS(node.right, level + 1, sums);
    }
  }
}
