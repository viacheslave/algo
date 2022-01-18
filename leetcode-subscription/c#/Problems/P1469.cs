using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-all-the-lonely-nodes/
  ///    Submission: https://leetcode.com/submissions/detail/451148641/
  ///    Microsoft
  /// </summary>
  internal class P1469
  {
    public class Solution
    {
      public IList<int> GetLonelyNodes(TreeNode root)
      {
        var ans = new List<int>();

        Rec(root, ans);
        return ans;
      }

      private void Rec(TreeNode node, List<int> ans)
      {
        if (node == null)
          return;

        if (node.left != null && node.right == null)
          ans.Add(node.left.val);

        if (node.left == null && node.right != null)
          ans.Add(node.right.val);

        Rec(node.left, ans);
        Rec(node.right, ans);
      }
    }
  }
}
