using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3838/
  /// 
  /// </summary>
  internal class Aug05
  {
    /**
     * Definition for a binary tree node.*/
     public class TreeNode {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
     }
     

    public class Solution
    {
      public IList<IList<int>> PathSum(TreeNode root, int sum)
      {
        var ss = new List<List<int>>();
        var sb = new List<int>();

        Drill(root, ss, sb);

        return ss
            .Where(elem => elem.Sum() == sum)
            .OfType<IList<int>>()
            .ToList();
      }

      private void Drill(TreeNode node, List<List<int>> ss, List<int> sb)
      {
        if (node == null)
          return;

        sb.Add(node.val);

        if (node.left == null && node.right == null)
        {
          ss.Add(new List<int>(sb));
          sb.RemoveAt(sb.Count - 1);
          return;
        }

        Drill(node.left, ss, sb);
        Drill(node.right, ss, sb);

        sb.RemoveAt(sb.Count - 1);
      }
    }
  }
}
