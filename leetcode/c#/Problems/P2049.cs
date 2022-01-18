namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-nodes-with-the-highest-score/
///    Submission: https://leetcode.com/submissions/detail/581118385/
/// </summary>
internal class P2049
{
  public class Solution
  {
    public int CountHighestScoreNodes(int[] parents)
    {
      // build the tree
      var nodes = new TreeNode[parents.Length];

      for (int i = 0; i < parents.Length; i++)
        nodes[i] = new TreeNode { Value = i };

      for (int i = 1; i < parents.Length; i++)
        nodes[parents[i]].Children.Add(nodes[i]);

      // recursive
      var res = new long[parents.Length];
      Recursive(res, nodes[0], parents.Length);

      var high = res.Max();
      return res.Count(x => x == high);
    }

    private int Recursive(long[] res, TreeNode treeNode, int length)
    {
      var product = 1L;
      var size = 0;

      foreach (var child in treeNode.Children)
      {
        var s = Recursive(res, child, length);
        if (s > 0)
        {
          product *= s;
          size += s;
        }
      }

      var topSize = length - size - 1;
      if (topSize > 0)
      {
        product *= topSize;
      }

      res[treeNode.Value] = product;
      return size + 1;
    }

    public class TreeNode
    {
      public List<TreeNode> Children = new List<TreeNode>();
      public int Value;
    }
  }

}
