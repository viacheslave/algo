package com.challenge.leetcode.twenty;

/*
 * Problem: https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/556/week-3-september-15th-september-21st/3462/
 * 
 */
public class Sep16 {
    class Solution {
        public int findMaximumXOR(int[] nums) {
            if (nums.length < 2)
                return 0;

            var max = Integer.MIN_VALUE;

            for (int i = 0; i < nums.length; i++) {
                for (int j = i + 1; j < nums.length; j++) {
                    max = Math.max(max, nums[i] ^ nums[j]);
                }
            }

            return max;
        }
    }
}