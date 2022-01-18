using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/inorder-successor-in-bst/
  ///    Submission: https://leetcode.com/submissions/detail/454474656/
  ///    All
  /// </summary>
  internal class P0285
  {
    public class Solution
    {
      public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
      {
        var list = new LinkedList<TreeNode>();

        Rec(root, list);

        var current = list.First;
        while (current.Value != p)
          current = current.Next;

        return current.Next?.Value ?? default;
      }

      private void Rec(TreeNode node, LinkedList<TreeNode> list)
      {
        if (node == null)
          return;

        Rec(node.left, list);

        list.AddLast(node);

        Rec(node.right, list);
      }
    }
  }
}
