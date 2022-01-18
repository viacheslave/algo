package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.TreeMap;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/recover-the-original-array/
 * Submission: https://leetcode.com/submissions/detail/607962578/
 */
public class P2122 {
  class Solution {
    public int[] recoverArray(int[] nums) {
      Arrays.sort(nums);

      // possible k
      var klist = new ArrayList<Integer>();
      for (int i = 1; i < nums.length; i++) {
        var diff = nums[i] - nums[0];
        if (diff % 2 == 0 && diff > 0) {
          klist.add(diff / 2);
        }
      }

      var ans = new int[nums.length / 2];
      var map = Arrays.stream(nums).boxed().collect(Collectors.groupingBy(x -> x, Collectors.counting()));

      for (var k : klist) {
        var tree = new TreeMap<>(map);
        var index = 0;

        while (!tree.isEmpty()) {
          var f = tree.firstKey();
          var l = f + k * 2;
          if (!tree.containsKey(l)) {
            break;
          }

          ans[index] = f + k;
          index++;

          tree.put(f, tree.get(f) - 1);
          tree.put(l, tree.get(l) - 1);

          if (tree.get(f) == 0)
            tree.remove(f);

          if (tree.get(l) == 0)
            tree.remove(l);
        }

        if (index == ans.length) {
          return ans;
        }
      }

      return ans;
    }
  }
}