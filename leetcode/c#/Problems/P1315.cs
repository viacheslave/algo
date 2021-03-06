namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sum-of-nodes-with-even-valued-grandparent/
///    Submission: https://leetcode.com/submissions/detail/293265273/
/// </summary>
internal class P1315
{
  public class Solution
  {
    public int SumEvenGrandparent(TreeNode root)
    {
      if (root == null)
        return 0;

      List<int> ans = new List<int>();
      Traverse(null, null, root, ans);
      return ans.Sum();
    }

    private void Traverse(TreeNode gp, TreeNode p, TreeNode node, List<int> sum)
    {
      if (node == null) return;

      if (gp?.val % 2 == 0)
        sum.Add(node.val);

      Traverse(p, node, node.left, sum);
      Traverse(p, node, node.right, sum);
    }
  }
}
