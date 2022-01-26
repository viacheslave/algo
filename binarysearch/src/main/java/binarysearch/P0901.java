package binarysearch;

import java.util.ArrayList;
import java.util.Map;

/*
 * Problem: https://binarysearch.com/problems/Contiguously-Increasing-Numbers
 * Submission: https://binarysearch.com/problems/Contiguously-Increasing-Numbers/submissions/7380556
 */
public class P0901 {
  class Solution {
    public int[] solve(int start, int end) {
      var startDigits = String.valueOf(start).length();
      var endDigits = String.valueOf(end).length();

      var ans = new ArrayList<Integer>();
      var template = "123456789";

      for (int length = startDigits; length <= endDigits ; length++) {
        for (var i = 0; i < template.length() - (length - 1); i++) {
          var num = Integer.parseInt(template.substring(i, i + length));
          if (start <= num && num <= end) {
            ans.add(num);
          }
        }
      }

      return ans.stream().mapToInt(x -> x).toArray();
    }
  }
}