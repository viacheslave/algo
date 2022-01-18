package binarysearch;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Longest-Fibonacci-Subsequence
 * Submission: https://binarysearch.com/problems/Longest-Fibonacci-Subsequence/submissions/6646236
 */
public class P0716 {
  class Solution {
    public int solve(int[] nums) {
      var ans = 0;

      var set = Arrays.stream(nums).boxed().collect(Collectors.toSet());

      for (var s1 = 0; s1 < nums.length - 2; s1++) {
        for (var s2 = s1 + 1; s2 < nums.length - 1; s2++) {
          var num1 = nums[s1];
          var num2 = nums[s2];

          var length = 2;

          while (true) {
            if (set.contains(num1 + num2)) {
              var next = num1 + num2;
              num1 = num2;
              num2 = next;
              length++;
              continue;
            }
            break;
          }

          ans = Math.max(ans, length);
        }
      }

      return ans == 2 ? 0 : ans;
    }
  }
}