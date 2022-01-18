using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/554/week-1-september-1st-september-7th/3449/
  ///    https://leetcode.com/submissions/detail/390887531/?from=/explore/challenge/card/september-leetcoding-challenge/554/week-1-september-1st-september-7th/3448/
  /// </summary>
  internal class Sep05
  {
    /**
    /* Definition for a binary tree node. */
    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }
 
    public class Solution
    {
      public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
      {
        var list1 = new List<int>();
        var list2 = new List<int>();

        Traverse(list1, root1);
        Traverse(list2, root2);

        list1.AddRange(list2);
        list1.Sort();
        return list1;
      }

      private void Traverse(List<int> list1, TreeNode root1)
      {
        if (root1 == null)
          return;

        list1.Add(root1.val);
        Traverse(list1, root1.left);
        Traverse(list1, root1.right);
      }
    }
  }
}
