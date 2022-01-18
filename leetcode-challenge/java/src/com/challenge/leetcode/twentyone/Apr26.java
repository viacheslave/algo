package com.challenge.leetcode.twentyone;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3721/
 * 
 */
public class Apr26 {
    class Solution {
        public int furthestBuilding(int[] heights, int bricks, int ladders) {
            var pq = new PriorityQueue<Integer>();

            var ans = 0;
            var sumH = 0;
            var sumLadders = 0;

            for (var i = 1; i < heights.length; i++) {
                var h = heights[i] - heights[i - 1];
                if (h <= 0) {
                    ans = i;
                    continue;
                }

                sumH += h;
                sumLadders += h;

                pq.add(h);

                if (pq.size() > ladders) {
                    int poll = pq.poll();
                    sumLadders -= poll;
                }

                if (sumH - sumLadders > bricks)
                    break;

                ans = i;
            }

            return ans;
        }
    }
}