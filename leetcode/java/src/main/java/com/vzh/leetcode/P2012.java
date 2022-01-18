package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/sum-of-beauty-in-the-array/
 * Submission: https://leetcode.com/submissions/detail/557435612/
 */
public class P2012 {
  class Solution {
    public int sumOfBeauties(int[] nums) {
      var pre = new int[nums.length + 1];

      var suf = new int[nums.length + 1];
      Arrays.fill(suf, Integer.MAX_VALUE);

      for (int i = 0; i < nums.length; i++) {
        pre[i + 1] = Math.max(pre[i], nums[i]);
        suf[nums.length - i - 1] = Math.min(suf[nums.length - i], nums[nums.length - i - 1]);
      }

      var ans = 0;

      for (int i = 1; i < nums.length - 1; i++) {
        if (pre[i] < nums[i] && nums[i] < suf[i + 1])
          ans += 2;
        else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1])
          ans += 1;
      }

      return ans;
    }
  }
}