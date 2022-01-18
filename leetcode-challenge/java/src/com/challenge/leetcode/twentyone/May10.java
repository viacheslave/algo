package com.challenge.leetcode.twentyone;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/599/week-2-may-8th-may-14th/3738/
 * 
 */
public class May10 {
    public class Solution {
        public int countPrimes(int n) {
            if (n < 2)
                return 0;

            var primes = new boolean[n];

            for (int i = 2; i * i < n; i++) {
                if (primes[i])
                    continue;

                for (int j = i * i; j < n; j += i) {
                    primes[j] = true;
                }
            }

            var ans = 0;

            for (int i = 2; i < n; i++) {
                if (!primes[i])
                    ans++;
            }

            return ans;
        }
    }
}