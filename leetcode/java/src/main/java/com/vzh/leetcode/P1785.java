package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/minimum-elements-to-add-to-form-a-given-sum/
 * Submission: https://leetcode.com/submissions/detail/573783820/
 */
public class P1785 {
  class Solution {
    public int minElements(int[] nums, int limit, int goal) {
      var sum = Arrays.stream(nums).mapToLong(x -> x).sum();
      var diff = Math.abs(1L * goal - sum);
      if (diff == 0)
        return 0;

      if (diff % limit == 0)
        return (int) (diff / limit);

      return (int) (diff / limit) + 1;
    }
  }
}