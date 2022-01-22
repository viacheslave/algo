package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Find-the-Largest-Number-in-a-Rotated-List
 * Submission: https://binarysearch.com/problems/Find-the-Largest-Number-in-a-Rotated-List/submissions/7352774
 */
public class P0033 {
  class Solution {
    public int solve(int[] arr) {
      var n = arr.length;

      if (arr[0] < arr[n - 1])
        return arr[n - 1];

      var left = 0;
      var right = n - 1;

      while (true) {
        if (right - left <= 1) {
          return Math.max(arr[left], arr[right]);
        }

        var mid = (left + right) >> 1;
        if (arr[mid] > arr[left] && arr[mid] > arr[right]) {
          left = mid;
        }
        else {
          right = mid;
        }
      }
    }
  }
}