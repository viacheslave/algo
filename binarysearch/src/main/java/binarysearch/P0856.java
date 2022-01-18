package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Eat-Bananas-in-K-Hours
 * Submission: https://binarysearch.com/problems/Eat-Bananas-in-K-Hours/submissions/6687287
 */
public class P0856 {
  class Solution {
    public int solve(int[] piles, int k) {
      var min = 1;
      var max = Arrays.stream(piles).max().getAsInt();

      while (max - min > 1) {
        var mid = (max + min) / 2;
        var fits = fits(piles, k, mid);

        if (fits)
          max = mid;
        else
          min = mid;
      }

      var minFits = fits(piles, k, min);

      return minFits ? min : max;
    }

    private boolean fits(int[] piles, int h, int mid) {
      var hours = 0;

      for (var pile : piles) {
        if (pile % mid == 0)
          hours += (pile / mid);
        else
          hours += (pile / mid) + 1;
      }

      return hours <= h;
    }
  }
}