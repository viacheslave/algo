using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/611/week-4-july-22nd-july-28th/3827/
  /// 
  /// </summary>
  internal class Jul26
  {
    /**
      * Definition for a binary tree node.*/
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
      public TreeNode SortedArrayToBST(int[] nums)
      {
        if (nums.Length == 0)
          return null;

        if (nums.Length == 1)
          return new TreeNode(nums[0]);

        return Fill(nums, 0, nums.Length - 1);
        ;
      }

      private TreeNode Fill(int[] nums, int start, int end)
      {
        var middle = (end + start) / 2;
        var node = new TreeNode(nums[middle]);

        if (start == end)
          return node;

        if (start != middle)
          node.left = Fill(nums, start, middle - 1);

        if (middle != end)
          node.right = Fill(nums, middle + 1, end);


        return node;
      }
    }
  }
}
