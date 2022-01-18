package com.vzh.leetcode;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid/
 * Submission: https://leetcode.com/submissions/detail/571317743/
 */
public class P2033 {
  class Solution {
    public int minOperations(int[][] grid, int x) {
      var arr = new int[grid.length * grid[0].length];

      for (var i = 0; i < grid.length; i++)
        for (var j = 0; j < grid[0].length; j++)
          arr[i * grid[0].length + j] = grid[i][j];

      var set = new HashSet<Integer>();
      for (var i = 0; i < arr.length; i++)
        set.add(arr[i] % x);

      // all items should similarly divide x
      if (set.size() > 1)
        return -1;

      Arrays.sort(arr);

      // find bottom point
      // binary search * n
      var left = 0;
      var right = (arr[arr.length - 1] - arr[0]) / x;

      while (true) {
        if (left + 1 >= right) {
          var ml = GetOperations(arr, left, x);
          var mr = GetOperations(arr, right, x);
          return Math.min(ml, mr);
        }

        var mid = (left + right) / 2;

        // check one left, one right
        var midops = GetOperations(arr, mid, x);
        var leftops = GetOperations(arr, mid - 1, x);
        var rightops = GetOperations(arr, mid + 1, x);

        if (leftops >= midops && rightops >= midops)
          return midops;

        if (leftops <= midops)
          right = mid;
        else
          left = mid;
      }
    }

    private int GetOperations(int[] arr, int index, int x) {
      var mid = arr[0] + x * index;

      var ret = 0;
      for (var i = 0; i < arr.length; i++) {
        ret += Math.abs(arr[i] - mid) / x;
      }

      return ret;
    }
  }
}