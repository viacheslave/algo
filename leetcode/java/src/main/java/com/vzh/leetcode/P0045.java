package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/jump-game-ii/
 * Submission: https://leetcode.com/submissions/detail/587661248/
 */
public class P0045 {
  class Solution {
    public int jump(int[] nums) {
      var tree = new TreeMap<Integer, Integer>();
      tree.put(nums.length - 1, 0);

      for (var i = nums.length - 2; i >= 0; i--) {
        if (nums[i] == 0)
          continue;

        var from = 1;
        var to = nums[i];

        var view = tree.subMap(i + from, true, i + to, true);

        if (view.size() == 0)
          continue;

        var min = Integer.MAX_VALUE;
        for (var item : view.entrySet()) {
          min = Math.min(item.getValue(), min);
        }

        tree.put(i, min + 1);
      }

      return tree.get(0);
    }
  }
}