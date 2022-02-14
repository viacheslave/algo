package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

/*
 * Problem: https://leetcode.com/problems/minimum-operations-to-make-the-array-alternating/
 * Submission: https://leetcode.com/submissions/detail/640520015/
 */
public class P2170 {
  class Solution {
    public int minimumOperations(int[] nums) {
      var n = nums.length;
      if (n <= 1)
        return 0;

      var even = IntStream.range(0, n)
        .filter(x -> x % 2 == 0)
        .map(x -> nums[x]).toArray();

      var odd = IntStream.range(0, n)
        .filter(x -> x % 2 == 1)
        .map(x -> nums[x]).toArray();

      var evenSet = Arrays.stream(even)
        .boxed()
        .collect(Collectors.groupingBy(x -> x, Collectors.counting()))
        .entrySet().stream()
        .sorted((a, b) -> (int)(b.getValue() - a.getValue()))
        .collect(Collectors.toList());

      var oddSet = Arrays.stream(odd)
        .boxed()
        .collect(Collectors.groupingBy(x -> x, Collectors.counting()))
        .entrySet().stream()
        .sorted((a, b) -> (int)(b.getValue() - a.getValue()))
        .collect(Collectors.toList());

      var ans = Integer.MAX_VALUE;

      for (int i = 0; i < evenSet.size(); i++) {
        if (i > 1)
          break;

        Map.Entry<Integer, Long> e1 = evenSet.get(i);
        for (int j = 0; j < oddSet.size(); j++) {
          if (j > 1)
            break;

          Map.Entry<Integer, Long> e2 = oddSet.get(j);
          if (e1.getKey().equals(e2.getKey())) {
            continue;
          }
          ans = Math.min(ans,
            (even.length - e1.getValue().intValue()) + (odd.length - e2.getValue().intValue()));
        }
      }

      if (ans == Integer.MAX_VALUE) {
        ans = Math.min(even.length, odd.length);
      }

      return ans;
    }
  }
}