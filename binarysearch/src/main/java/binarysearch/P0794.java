package binarysearch;

import java.util.HashSet;

/*
 * Problem: https://binarysearch.com/problems/Split-String-with-Same-Distinct-Counts
 * Submission: https://binarysearch.com/problems/Split-String-with-Same-Distinct-Counts/submissions/7019626
 */
public class P0794 {
  class Solution {
    public int solve(String s) {
      var prefixNum = new int[s.length()];
      var suffixSum = new int[s.length()];

      var set = new HashSet<Character>();

      for (int i = 0; i < s.length(); i++) {
        set.add(s.charAt(i));
        prefixNum[i] = set.size();
      }

      set.clear();

      for (int i = s.length() - 1; i >= 0; i--) {
        set.add(s.charAt(i));
        suffixSum[i] = set.size();
      }

      var ans = 0;

      for (int i = 0; i < s.length() - 1; i++) {
        if (prefixNum[i] == suffixSum[i + 1])
          ans++;
      }

      return ans;
    }
  }
}