using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/573/week-5-december-29th-december-31st/3585/
  ///    https://leetcode.com/submissions/detail/435906667/?from=explore&item_id=3585
  /// </summary>
  internal class Dec29
  {
    /**
     * Definition for a binary tree node.*/
     public class TreeNode {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
             this.val = val;
             this.left = left;
             this.right = right;
         }
     }
     

    public class Solution
    {
      public int PseudoPalindromicPaths(TreeNode root)
      {
        var list = new List<int>();
        return Traverse(root, list);
      }

      private int Traverse(TreeNode node, List<int> list)
      {
        if (node == null)
          return 0;

        list.Add(node.val);

        var val = 0;

        if (node.left == null && node.right == null)
          val = IsPalindrome(list) ? 1 : 0;
        else
          val = Traverse(node.left, list) + Traverse(node.right, list);

        list.RemoveAt(list.Count - 1);

        return val;
      }

      private bool IsPalindrome(List<int> list)
      {
        var odds = list.GroupBy(d => d).ToDictionary(x => x.Key, x => x.Count())
          .Where(x => x.Value % 2 == 1)
          .Count();

        return odds <= 1;
      }
    }
  }
}
