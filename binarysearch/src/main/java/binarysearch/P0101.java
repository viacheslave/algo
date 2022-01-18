package binarysearch;

import java.util.ArrayList;
import java.util.Map;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Removing-Parentheses
 * Submission: https://binarysearch.com/problems/Removing-Parentheses/submissions/6975686
 */
public class P0101 {
  class Solution {
    public int solve(String s) {
      var stack = new Stack<Character>();
      var ans = 0;

      for (int i = 0; i < s.length(); i++) {
        if (s.charAt(i) == '(') {
          stack.add(s.charAt(i));
          continue;
        }

        if (stack.empty()) {
          ans++;
          continue;
        }

        if (stack.peek() == '(') {
          stack.pop();
        }
      }

      return ans + stack.size();
    }
  }
}