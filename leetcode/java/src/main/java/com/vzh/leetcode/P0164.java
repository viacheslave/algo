package com.vzh.leetcode;

import java.util.ArrayList;

/*
 * Problem: https://leetcode.com/problems/maximum-gap/
 * Submission: https://leetcode.com/submissions/detail/602400962/
 */
public class P0164 {
  class Solution {
    public int maximumGap(int[] nums) {
      // poor man's radix sort

      for (int i = 0; i < 10; i++) {
        nums = sort(nums, i);
      }

      var ans = 0;
      for (var i = 1; i < nums.length; i++) {
        ans = Math.max(ans, nums[i] - nums[i - 1]);
      }

      return ans;
    }

    private int[] sort(int[] nums, int radix) {
      var div = (int)Math.pow(10, radix);

      var arr = new ArrayList<ArrayList<Integer>>(10);
      for (int i = 0; i < 10; i++) {
        arr.add(new ArrayList<>());
      }

      for (int i = 0; i < nums.length; i++) {
        var num = nums[i];
        var p = num / div;
        var digit = p % 10;

        arr.get(digit).add(num);
      }

      var ans = new int[nums.length];
      var index = 0;

      for (var el : arr) {
        for (var inner : el) {
          ans[index] = inner;
          index++;
        }
      }

      return ans;
    }
  }
}