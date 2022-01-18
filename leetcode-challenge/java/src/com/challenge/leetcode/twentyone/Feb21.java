package com.challenge.leetcode.twentyone;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/586/week-3-february-15th-february-21st/3647/
 * 
 */
public class Feb21 {
    class Solution {
        public int brokenCalc(int X, int Y) {
            var ans = 0;
            var current = Y;

            while (X != current)
            {
                if (current % 2 == 1)
                {
                    current++;
                    ans++;
                    continue;
                }

                if (current >= X && X < current)
                {
                    current /= 2;
                    ans++;
                    continue;
                }

                current++;
                ans++;
            }

            return ans;
        }
    }
}