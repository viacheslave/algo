using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3661/
  /// 
  /// </summary>
  internal class Mar05
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
      public IList<double> AverageOfLevels(TreeNode root)
      {
        var res = new List<IList<int>>();

        CheckNode(res, root, 0);

        var av = new List<double>();

        foreach (var r in res)
        {
          long sum = 0;
          foreach (var el in r)
            sum += el;

          av.Add(1.0 * sum / r.Count);
        }

        return av;
      }

      private void CheckNode(List<IList<int>> res, TreeNode node, int depth)
      {
        if (node == null)
          return;

        if (res.Count == depth)
          res.Add(new List<int>());

        res[depth].Add(node.val);

        depth++;

        if (node.left != null)
          CheckNode(res, node.left, depth);

        if (node.right != null)
          CheckNode(res, node.right, depth);
      }
    }
  }
}
