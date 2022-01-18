package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/minimum-operations-to-make-the-array-k-increasing/
 * Submission: https://leetcode.com/submissions/detail/603971016/
 */
public class P2111 {
  class Solution {
    public int kIncreasing(int[] arr, int k) {
      var ans = 0;

      for (var s = 0; s < k; s++) {
        var a = new ArrayList<Integer>();
        var index = s;
        var increasing = 0;

        while (index < arr.length) {
          a.add(arr[index]);

          if (a.size() > 1 && arr[index - k] <= arr[index])
            increasing++;

          index += k;
        }

        // some early observations
        if (increasing == 0) {
          ans += a.size() - 1;
        }
        else if (increasing == a.size() - 1) {
          ans += 0;
        }
        else {
          // base on LIS
          var lisLength = LISLength(a);
          ans += a.size() - lisLength;
        }
      }

      return ans;
    }

    private int LISLength(ArrayList<Integer> a) {
      var dp = new int[a.size()];
      Arrays.fill(dp, 1);

      for (var i = 1; i < a.size(); i++)
        for (var j = 0; j < i; j++)
          if (a.get(i) >= a.get(j) && dp[i] < dp[j] + 1)
            dp[i] = dp[j] + 1;

      return Arrays.stream(dp).max().getAsInt();
    }
  }
}