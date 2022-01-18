package com.challenge.leetcode.twenty;

import java.util.HashMap;
import java.util.TreeMap;
import java.util.TreeSet;

/*
 * Problem: https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/552/week-4-august-22nd-august-28th/3438/
 * Submission: https://leetcode.com/submissions/detail/387099696/?from=/explore/challenge/card/august-leetcoding-challenge/552/week-4-august-22nd-august-28th/3438/
 */
public class Aug27 {
    class Solution {
        public int[] findRightInterval(int[][] intervals) {
            var treeMap = new TreeMap<Integer, Integer>();
            var indexMap = new HashMap<Integer, Integer>();

            for (int i = 0; i < intervals.length; i++) {
                int[] interval = intervals[i];
                treeMap.put(interval[0], interval[1]);
                indexMap.put(interval[0], i);
            }

            var ans = new int[intervals.length];

            for (int i = 0; i < intervals.length; i++) {
                int[] interval = intervals[i];
                var rightEdge = interval[1];

                if (treeMap.containsKey(rightEdge))
                    ans[i] = indexMap.get(rightEdge);
                else {
                    var ceiling = treeMap.ceilingEntry(rightEdge);
                    if (ceiling != null) {
                        var key = ceiling.getKey();
                        var index = indexMap.get(key);
                        ans[i] = index;
                    } else {
                        ans[i] = -1;
                    }
                }
            }

            return ans;
        }
    }
}