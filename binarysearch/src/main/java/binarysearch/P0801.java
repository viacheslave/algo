package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Quadratic-Application
 * Submission: https://binarysearch.com/problems/Quadratic-Application/submissions/7591749
 */
public class P0801 {
  class Solution {
    public int[] solve(int[] nums, int a, int b, int c) {
      var n = nums.length;
      if (n == 0) {
        return new int[0];
      }

      if (n == 1) {
        return new int[] { calc(nums[0], a, b, c) };
      }

      if (a == 0) {
        return getZeroA(nums, b, c);
      }

      var midpoint = -1d * b / (2 * a);
      var orientation = a < 0 ? -1 : 1;

      var corrected = new double[n];
      for (int i = 0; i < n; i++) {
        corrected[i] = nums[i] - midpoint;
      }

      var ans = new ArrayList<Integer>();
      var left = 0;
      var right = n - 1;

      while (left <= right) {
        var leftValue = calc((int)Math.round(corrected[left] + midpoint), a, b, c);
        var rightValue = calc((int)Math.round(corrected[right] + midpoint), a, b, c);

        if ((leftValue < rightValue && orientation == -1) || (leftValue > rightValue && orientation == 1)) {
          ans.add(leftValue);
          left++;
        }
        else {
          ans.add(rightValue);
          right--;
        }
      }

      var arr = ans.stream().mapToInt(x -> x).toArray();
      return ascending(arr);
    }

    private int[] getZeroA(int[] nums, int b, int c) {
      var ans = new int[nums.length];
      for (var i = 0; i < nums.length; i++) {
        ans[i] = b * nums[i] + c;
      }

      return ascending(ans);
    }

    private int[] ascending(int[] arr) {
      if (arr[0] > arr[arr.length - 1]) {
        var list = Arrays.stream(arr).boxed().collect(Collectors.toList());
        Collections.reverse(list);
        return list.stream().mapToInt(x -> x).toArray();
      }
      return arr;
    }

    private int calc(int num, int a, int b, int c) {
      return num * num * a + num * b + c;
    }
  }
}