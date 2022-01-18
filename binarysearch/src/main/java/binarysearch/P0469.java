package binarysearch;

import java.util.Arrays;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/K-Compare
 * Submission: https://binarysearch.com/problems/K-Compare/submissions/7152850
 */
public class P0469 {
  class Solution {
    public int solve(int[] a, int[] b, int k) {
      if (k == 0)
        return a.length;

      if (a.length == 0 || b.length == 0)
        return 0;

      Arrays.sort(b);
      var kth = b[b.length - k] - 1;

      Arrays.sort(a);
      var index = a.length - 1;
      while (index >= 0 && a[index] > kth) {
        index--;
      }

      return index + 1;
    }
  }
}