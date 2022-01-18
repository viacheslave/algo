package binarysearch;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Number-of-Sublists-With-Odd-Sum
 * Submission: https://binarysearch.com/problems/Number-of-Sublists-With-Odd-Sum/submissions/7120315
 */
public class P0914 {
  class Solution {
    public int solve(int[] nums) {
      if (nums.length == 0)
        return 0;

      var odd = new int[nums.length];
      var even = new int[nums.length];

      if (nums[0] % 2 == 0) {
        even[0] = 1;
      }
      else {
        odd[0] = 1;
      }

      var mod = (int)1e9 + 7;

      for (int i = 1; i < nums.length; i++) {
        if (nums[i] % 2 == 0) {
          // even
          even[i] = even[i - 1] + 1;
          odd[i] = odd[i - 1];
        }
        else {
          // odd
          even[i] = odd[i - 1];
          odd[i] = even[i - 1] + 1;
        }

        odd[i] %= mod;
        even[i] %= mod;
      }

      var ans = 0;
      for (int i = 0; i < odd.length; i++) {
        ans += odd[i];
        ans %= mod;
      }

      return ans;
    }
  }
}