namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/create-binary-tree-from-descriptions/
///    Submission: https://leetcode.com/submissions/detail/656641043/
/// </summary>
internal class P2196
{
  public class Solution
  {
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
      var nodes = new Dictionary<int, TreeNode>();

      foreach (var description in descriptions)
      {
        nodes.TryGetValue(description[0], out var parent);
        nodes.TryGetValue(description[1], out var child);

        if (parent == null)
        {
          parent = new TreeNode(description[0]);
          nodes[description[0]] = parent;
        }

        if (child == null)
        {
          child = new TreeNode(description[1]);
          nodes[description[1]] = child;
        }

        if (description[2] == 1)
          parent.left = child;
        else
          parent.right = child;
      }

      var children = nodes.Values.SelectMany(x => new[] { x.left, x.right }).Distinct().ToList();

      return nodes.Values.Except(children).Single();
    }
  }

}
