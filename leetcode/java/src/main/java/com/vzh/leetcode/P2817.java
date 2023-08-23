package com.vzh.leetcode;

import java.util.*;

/**
 * Problem: https://leetcode.com/problems/minimum-absolute-difference-between-elements-with-constraint/
 * Submission: https://leetcode.com/problems/minimum-absolute-difference-between-elements-with-constraint/submissions/1022382783/
 */
public class P2817 {
  class Solution {
    public int minAbsoluteDifference(List<Integer> nums, int x) {
      TreeSet<Integer> treeSet = new TreeSet<>();
      int ans = Integer.MAX_VALUE;

      for (int i = x; i < nums.size(); i++) {
        treeSet.add(nums.get(i - x));

        Integer floor = treeSet.floor(nums.get(i));
        Integer ceiling = treeSet.ceiling(nums.get(i));

        if (floor != null) {
          ans = Math.min(ans, Math.abs(nums.get(i) - floor));
        }

        if (ceiling != null) {
          ans = Math.min(ans, Math.abs(nums.get(i) - ceiling));
        }
      }

      return ans;
    }
  }
}
