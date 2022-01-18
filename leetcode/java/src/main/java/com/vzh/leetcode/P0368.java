package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/largest-divisible-subset/
 * Submission: https://leetcode.com/submissions/detail/587582980/
 */
public class P0368 {
  class Solution {
    public List<Integer> largestDivisibleSubset(int[] nums) {
      Arrays.sort(nums);
      var set = Arrays.stream(nums).boxed().collect(Collectors.toSet());

      // dp = max length of chain for current number
      // factors = last coefficient for current number
      var dp = new HashMap<Integer, Integer>();
      var factors = new HashMap<Integer, Integer>();

      for (int i = 0; i < nums.length; i++) {
        dp.put(nums[i], 1);
        factors.put(nums[i], 1);

        for (int j = 0; j < i; j++) {
          if (nums[i] % nums[j] == 0) {
            if (dp.get(nums[j]) + 1 > dp.get(nums[i])) {
              dp.put(nums[i], dp.get(nums[j]) + 1);

              var factor = nums[i] / nums[j];
              factors.put(nums[i], factor);
            }
          }
        }
      }

      var maxEntry = dp.entrySet().stream()
        .max((e1, e2) -> e1.getValue() - e2.getValue())
        .get();

      // check backwards
      var ans = new ArrayList<Integer>();
      var current = maxEntry.getKey();
      var factor = factors.get(current);

      while (current > 0) {
        ans.add(current);
        if (factor == 1)
          break;

        current /= factor;
        factor = factors.get(current);
      }

      return ans;
    }
  }
}