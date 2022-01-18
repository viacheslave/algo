package com.challenge.leetcode.twentyone;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/602/week-5-may-29th-may-31st/3762/
 * 
 */
public class May31 {
    class Solution {
        public List<List<String>> suggestedProducts(String[] products, String searchWord) {
            Arrays.sort(products);

            var ans = new ArrayList<List<String>>();

            for (int i = 1; i <= searchWord.length(); i++)
            {
                var input = searchWord.substring(0, i);

                var list = Arrays.stream(products)
                        .filter(p -> p.startsWith(input))
                        .limit(3)
                        .collect(Collectors.toList());

                ans.add(list);
            }

            return ans;
        }
    }
}