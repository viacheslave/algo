package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

/*
 * Problem: https://leetcode.com/problems/intervals-between-identical-elements/
 * Submission: https://leetcode.com/submissions/detail/607938522/
 */
public class P2121 {
  class Solution {
    public long[] getDistances(int[] arr) {
      var indicesMap = new HashMap<Integer, List<Integer>>();
      var intervalMap = new HashMap<Integer, List<Long>>();
      var sums = new HashMap<Integer, Long>();
      var runningIndex = new HashMap<Integer, Integer>();

      for (int i = 0; i < arr.length; i++) {
        indicesMap.putIfAbsent(arr[i], new ArrayList<>());
        indicesMap.get(arr[i]).add(i);
      }

      for (var e : indicesMap.entrySet()) {
        intervalMap.put(e.getKey(), new ArrayList<>());

        var key = e.getKey();
        var indices = e.getValue();

        var s = new long[indices.size()];
        for (int i = 1; i < indices.size(); i++) {
          s[i] = s[i - 1] +  (indices.get(i) - indices.get(i - 1));
        }

        sums.put(key, Arrays.stream(s).sum());
      }

      for (var e : sums.entrySet()) {
        var list = intervalMap.get(e.getKey());
        var indices = indicesMap.get(e.getKey());
        var sum = e.getValue();

        long left = 0;
        long right = sum;

        list.add(sum);

        for (int i = 1; i < indices.size(); i++) {
          var interval = indices.get(i) - indices.get(i - 1);

          left += interval * i;
          right -= interval * (indices.size() - i);

          list.add(left + right);
        }
      }

      for (var e : sums.entrySet()) {
        runningIndex.put(e.getKey(), 0);
      }

      var ans = new long[arr.length];

      for (int i = 0; i < arr.length; i++) {
        var num = arr[i];
        var list = intervalMap.get(num);
        var index = runningIndex.get(num);
        ans[i] = list.get(index);

        runningIndex.put(num, runningIndex.get(num) + 1);
      }

      return ans;
    }
  }
}