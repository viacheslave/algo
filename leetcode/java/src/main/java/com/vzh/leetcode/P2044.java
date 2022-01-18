package com.vzh.leetcode;

/*
 * Problem: https://leetcode.com/problems/count-number-of-maximum-bitwise-or-subsets/
 * Submission: https://leetcode.com/submissions/detail/572625501/
 */
public class P2044 {
  class Solution {
    public int countMaxOrSubsets(int[] nums) {
      var maxOr = 0;
      for (var i = 0; i < nums.length; i++)
        maxOr = maxOr | nums[i];

      var ans = rec(nums, 0, 0, maxOr);
      return ans;
    }

    private int rec(int[] nums, int index, int result, int maxOr) {
      var r1 = result | nums[index];
      var r2 = result;

      var ans = 0;
      if (index == nums.length - 1) {
        if (r1 == maxOr)
          ans++;
        if (r2 == maxOr)
          ans++;
        return ans;
      }

      ans += rec(nums, index + 1, r1, maxOr);
      ans += rec(nums, index + 1, r2, maxOr);
      return ans;
    }
  }
}