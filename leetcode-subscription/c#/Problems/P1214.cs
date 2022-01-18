using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/two-sum-bsts/
  ///    Submission: https://leetcode.com/submissions/detail/453299164/
  ///    SoundHound
  /// </summary>
  internal class P1214
  {
    public class Solution
    {
      public bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target)
      {
        var n1 = new List<int>();
        var n2 = new List<int>();

        GetNodes(root1, n1);
        GetNodes(root2, n2);

        var left = 0;
        var right = n2.Count - 1;

        while (left < n1.Count)
        {
          while (right > 0 && n1[left] + n2[right] > target)
            right--;

          if (n1[left] + n2[right] == target)
            return true;

          left++;
        }

        return false;
      }

      private void GetNodes(TreeNode node, List<int> list)
      {
        if (node == null)
          return;

        GetNodes(node.left, list);

        list.Add(node.val);

        GetNodes(node.right, list);
      }
    }
  }
}
