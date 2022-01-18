package binarysearch;

import binarysearch.templates.Tree;

/*
 * Problem: https://binarysearch.com/problems/List-to-Binary-Search-Tree
 * Submission: https://binarysearch.com/problems/List-to-Binary-Search-Tree/submissions/7154822
 */
public class P0225 {
  class Solution {
    public Tree solve(int[] nums) {
      return construct(nums, 0, nums.length - 1);
    }

    private Tree construct(int[] nums, int left, int right) {
      if (left > right)
        return null;

      int rootIndex = (left + right) >> 1;
      if ((right - left) % 2 == 1) {
        rootIndex ++;
      }

      var root = new Tree();
      root.val = nums[rootIndex];
      root.left = construct(nums, left, rootIndex - 1);
      root.right = construct(nums, rootIndex + 1, right);

      return root;
    }
  }
}