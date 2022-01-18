package binarysearch;

import java.util.Arrays;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Length-of-Longest-Balanced-Subsequence
 * Submission: https://binarysearch.com/problems/Length-of-Longest-Balanced-Subsequence/submissions/7313626
 */
public class P0466 {
  class Solution {
    public int solve(String s) {
      var stack = new Stack<Character>();
      var ans = 0;

      for (int i = 0; i < s.length(); i++) {
        var ch = s.charAt(i);
        if (ch == '(') {
          stack.add(ch);
          continue;
        }

        if (!stack.empty()) {
          stack.pop();
          ans += 2;
        }
      }

      return ans;
    }
  }
}