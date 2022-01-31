package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Bit-Sum
 * Submission: https://binarysearch.com/problems/Bit-Sum/submissions/7430486
 */
public class P0516 {
  class Solution {
    public int solve(int[] nums, int k) {
      var n  = nums.length;

      var bits = new int[31];

      for (var num : nums) {
        for (int i = 0; i < 31; i++) {
          if (num % 2 == 1)
            bits[i]++;
          num >>= 1;
        }
      }

      var mod = (int)1e9 + 7;
      var diff = 0;

      for (var i = 0; i < 31; i++) {
        var d = Math.min(n - bits[i], k);
        diff += (1 << i) * d;
        diff %= mod;

        k -= d;

        if (k == 0)
          break;
      }

      var sum = 0;
      for (var num : nums) {
        sum += num;
        sum %= ((int)1e9 + 7);
      }

      return sum + diff;
    }
  }
}