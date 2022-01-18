package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/maximum-number-of-weeks-for-which-you-can-work/
 * Submission: https://leetcode.com/submissions/detail/532815809/
 */
public class P1953 {
  class Solution {
    public long numberOfWeeks(int[] milestones) {
      Arrays.sort(milestones);

      var arrSum = Arrays.stream(milestones).mapToLong(d -> d * 1L).sum();

      var partSum = arrSum - milestones[milestones.length - 1];
      if (partSum >= milestones[milestones.length - 1])
        return arrSum;

      return partSum * 2 + 1;
    }
  }
}