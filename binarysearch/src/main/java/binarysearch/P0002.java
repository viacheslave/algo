package binarysearch;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Balanced-Brackets
 * Submission: https://binarysearch.com/problems/Balanced-Brackets/submissions/6943814
 */
public class P0002 {
  class Solution {
    public boolean solve(String s) {
      var stack = new Stack<Character>();
      for (int i = 0; i < s.length(); i++) {
        var ch = s.charAt(i);
        if (ch == ')') {
          if (!stack.empty() && stack.peek() == '(')
            stack.pop();
          else
            stack.add(ch);
        }
        else {
          stack.add(ch);
        }
      }

      return stack.empty();
    }
  }
}