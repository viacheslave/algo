package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/keep-multiplying-found-values-by-two/
 * Submission: https://leetcode.com/submissions/detail/631172032/
 */
public class P2154 {
  class Solution {
    public int findFinalValue(int[] nums, int original) {
      var set = Arrays.stream(nums).boxed().collect(Collectors.toSet());

      while (set.contains(original)) {
        original *= 2;
      }

      return original;
    }
  }
}