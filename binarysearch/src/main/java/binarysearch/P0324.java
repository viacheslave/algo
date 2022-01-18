package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Bus-Fare
 * Submission: https://binarysearch.com/problems/Bus-Fare/submissions/7089647
 */
public class P0324 {
  class Solution {
    public int solve(int[] days) {
      var set = new TreeMap<Integer, Integer>();

      for (int i = 0; i < days.length; i++) {
        set.put(days[i], i);
      }

      var dp = new int[days.length];

      // 1 - 2
      // 7 - 7
      // 30 - 25

      for (int i = days.length - 1; i >= 0; i--) {
        var day = days[i];

        var pass1 = getPrice(dp, set,day + 1, 2);
        var pass7 = getPrice(dp, set,day + 7, 7);
        var pass30 = getPrice(dp, set,day + 30, 25);

        dp[i] = Math.min(pass1, Math.min(pass7, pass30));
      }

      return dp[0];
    }

    private int getPrice(int[] dp, TreeMap<Integer, Integer> set, int day, int ticket) {
      var entry = set.ceilingEntry(day);
      var entryValue = ticket;
      if (entry != null) {
        entryValue += dp[entry.getValue()];
      }

      return entryValue;
    }
  }
}