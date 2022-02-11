package binarysearch;

import java.util.ArrayList;
import java.util.Collections;
import java.util.stream.IntStream;

/*
 * Problem: https://binarysearch.com/problems/View-Over-People
 * Submission: https://binarysearch.com/problems/View-Over-People/submissions/7525344
 */
public class P0965 {
  class Solution {
    public int[] solve(int[] heights, int k) {
      var max = Integer.MIN_VALUE;
      var n = heights.length;

      if (k == 0) {
        return IntStream.rangeClosed(0, n - 1).toArray();
      }

      // build left and rihgt k-max chunks
      var left = new int[n];
      var right = new int[n];

      for (int i = 0; i < n; i++) {
        if (i % k == 0) {
          max = Integer.MIN_VALUE;
        }
        max = Math.max(max, heights[i]);
        left[i] = max;
      }

      max = Integer.MIN_VALUE;
      for (int i = n - 1; i >= 0; i--) {
        if ((i + 1) % k == 0) {
          max = Integer.MIN_VALUE;
        }
        max = Math.max(max, heights[i]);
        right[i] = max;
      }

      var ans = new ArrayList<Integer>();
      var mx = new int[n];

      for (var i = n - 1; i >=0; i--) {
        if (i == n - 1) {
          mx[i] = heights[i];
        }
        else {
          mx[i] = Math.max(mx[i + 1], heights[i]);
        }
      }

      for (var i = n - 1; i >=0; i--) {
        var start = i + 1;
        var end = start + k - 1;
        var value = Integer.MAX_VALUE;

        if (start >= n) {
          ans.add(i);
          continue;
        }
        else if (end >= n) {
          value = mx[start];
        }
        else if (start == end) {
          value = heights[start];
        }
        else {
          // essential
          value = Math.max(left[end], right[start]);
        }

        if (heights[i] > value) {
          ans.add(i);
        }
      }

      Collections.reverse(ans);
      return ans.stream().mapToInt(x -> x).toArray();
    }
  }
}