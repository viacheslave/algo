package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Arrange-Symbols-to-Create-Sum
 * Submission: https://binarysearch.com/problems/Arrange-Symbols-to-Create-Sum/submissions/6708660
 */
public class P0633 {
  class Solution {
    public int solve(int[] nums, int target) {
      var ans = 0;
      var max = (int)Math.pow(2, nums.length);

      for (var i = 0; i < max; i++) {
        var sum = 0;
        var current = i;

        for (var j = 0; j < nums.length; j++) {
          if (current % 2 == 0)
            sum += nums[j];
          else
            sum -= nums[j];

          current >>= 1;
        }

        if (sum == target)
          ans++;
      }

      return ans;
    }
  }
}