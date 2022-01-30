package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/all-divisions-with-the-highest-score-of-a-binary-array/
 * Submission: https://leetcode.com/submissions/detail/631169912/
 */
public class P2155 {
  class Solution {
    public List<Integer> maxScoreIndices(int[] nums) {
      var n = nums.length;
      var prefixZeros = new int[n + 1];
      var suffixOnes = new int[n + 1];

      for (int i = 0; i < n; i++) {
        prefixZeros[i + 1] = prefixZeros[i] + (nums[i] == 0 ? 1 : 0);
        suffixOnes[n - i - 1] = suffixOnes[n - i] + (nums[n - i - 1] == 1 ? 1 : 0);
      }

      var results = new int[n + 1];

      for (int i = 0; i <= n; i++) {
        results[i] = prefixZeros[i] + suffixOnes[i];
      }

      var highest = Arrays.stream(results).max().getAsInt();
      var ans = new ArrayList<Integer>();

      for (int i = 0; i < results.length; i++) {
        if (results[i] == highest) {
          ans.add(i);
        }
      }

      return ans;
    }
  }
}