package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

/*
 * Problem: https://binarysearch.com/problems/Bounded-Square-Sums
 * Submission: https://binarysearch.com/problems/Bounded-Square-Sums/submissions/7331885
 */
public class P0979 {
  class Solution {
    public int solve(int[] a, int[] b, int lower, int upper) {
      if (a.length == 0 || b.length == 0)
        return 0;

      var arr1 = Arrays.stream(a).map(x -> (int)Math.pow(x, 2)).toArray();
      var arr2 = Arrays.stream(b).map(x -> (int)Math.pow(x, 2)).toArray();

      Arrays.sort(arr2);

      var ans = 0;

      // for each element in a
      // O(n)
      for (int i = 0; i < arr1.length; i++) {
        // binary search
        var lowerIndex = getLower(arr2, lower - arr1[i]);
        var upperIndex = getUpper(arr2, upper - arr1[i]);

        if (lowerIndex == -1 || upperIndex == -1)
          continue;

        ans += upperIndex - lowerIndex + 1;
      }

      return ans;
    }

    private int getLower(int[] arr, int num) {
      var left = 0;
      var right = arr.length - 1;

      while (true) {
        if (right - left <= 1) {
          if (arr[left] >= num)
            return left;
          if (arr[right] >= num)
            return right;
          return -1;
        }

        var mid = (left + right) >> 1;
        if (arr[mid] < num) {
          left = mid;
        }
        else {
          right = mid;
        }
      }
    }

    private int getUpper(int[] arr, int num) {
      var left = 0;
      var right = arr.length - 1;

      while (true) {
        if (right - left <= 1) {
          if (arr[right] <= num)
            return right;
          if (arr[left] <= num)
            return left;
          return -1;
        }

        var mid = (left + right) >> 1;
        if (arr[mid] > num) {
          right = mid;
        }
        else {
          left = mid;
        }
      }
    }

  }
}