package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Hoppable
 * Submission: https://binarysearch.com/problems/Hoppable/submissions/7108565
 */
public class P0004 {
  class Solution {
    public boolean solve(int[] nums) {
      var dp = new boolean[nums.length];

      // implies we can reach end
      dp[nums.length - 1] = true;

      for (int i = nums.length - 2; i >= 0; i--) {
        var can = false;

        for (var j = i + 1; j <= i + nums[i]; j++) {
          if (j == nums.length) {
            break;
          }

          can = can || dp[j];
        }
        dp[i] = can;
      }

      return dp[0];
    }
  }
}