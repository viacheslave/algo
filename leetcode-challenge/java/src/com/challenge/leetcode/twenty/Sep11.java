package com.challenge.leetcode.twenty;

/*
 * Problem: https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3456/
 * Submission: https://leetcode.com/submissions/detail/394160506/?from=/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3456/
 */
public class Sep11 {
    class Solution {
        public int maxProduct(int[] nums) {
            var dp = new int[nums.length];
    
            var ans = Integer.MIN_VALUE;
    
            for (var i =0; i < nums.length; i++) {
                dp[i] = nums[i];
    
                var max = dp[i];
    
                for (var j = 0; j < i; j++) {
                    dp[j] *= nums[i];
                    max = Math.max(max, dp[j]);
                }
    
                ans = Math.max(ans, max);
            }
    
            return ans;
        }
    }
}