package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Bubble-Swap
 * Submission: https://binarysearch.com/problems/Bubble-Swap/submissions/7295458
 */
public class P0429 {
  class Solution {
    public int solve(int[] lst0, int[] lst1) {
      var n = lst0.length;
      var indices = new int[n];

      for (int i = 0; i < n; i++) {
        indices[lst1[i]] = i;
      }

      var arr = new int[n];
      for (int i = 0; i < n; i++) {
        arr[i] = indices[lst0[i]];
      }

      // bubble sort arr
      var ans = 0;

      var swapped = true;
      while (swapped) {
        swapped = false;

        for (int i = 0; i < n - 1; i++) {
          if (arr[i] > arr[i + 1]) {
            var temp = arr[i];
            arr[i] = arr[i + 1];
            arr[i + 1] = temp;

            swapped = true;
            ans++;
          }
        }
      }

      return ans;
    }
  }
}