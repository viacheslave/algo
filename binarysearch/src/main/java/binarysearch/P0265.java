package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Minimum-Difference
 * Submission: https://binarysearch.com/problems/Minimum-Difference/submissions/6963479
 */
public class P0265 {
  class Solution {
    public int solve(int[] lst0, int[] lst1) {
      var min = Integer.MAX_VALUE;
      Arrays.sort(lst1);

      for (var i = 0; i < lst0.length; i++) {
        var value = getMin(lst0[i], lst1);
        min = Math.min(min, value);
      }

      return min;
    }

    private int getMin(int num, int[] list) {
      // Binary Search
      if (num <= list[0])
        return list[0] - num;

      if (num >= list[list.length - 1])
        return num - list[list.length - 1];

      var l = 0;
      var r = list.length - 1;

      while (l < r) {
        if (r - l <= 1)
          break;

        var mid = (l + r) >> 1;
        if (num == list[mid])
          return 0;

        if (num > list[mid])
          l = mid;
        else
          r = mid;
      }

      return Math.min(
        Math.abs(num - list[l]),
        Math.abs(num - list[r])
      );
    }
  }
}