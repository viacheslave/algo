package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Count-Substrings-With-All-1s
 * Submission: https://binarysearch.com/problems/Count-Substrings-With-All-1s/submissions/7313352
 */
public class P0917 {
  class Solution {
    public int solve(String s) {
      var start = -1;
      var intervals = new ArrayList<Integer[]>();

      for (int i = 0; i < s.length(); i++) {
        if (s.charAt(i) == '1') {
          if (start == -1)
            start = i;

          continue;
        }

        if (s.charAt(i) == '0') {
          if (start != -1) {
            intervals.add(new Integer[] { start, i - 1 });
            start = -1;
          }
        }
      }

      if (start != -1) {
        intervals.add(new Integer[] {start, s.length() - 1});
      }

      var ans = 0;
      for (var i : intervals) {
        var length = i[1] - i[0] + 1;
        ans += length * (length + 1) / 2;
        ans %= (int)(1e9 + 7);
      }

      return ans;
    }
  }
}