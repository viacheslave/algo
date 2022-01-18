package binarysearch;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Balanced-Brackets-Sequel
 * Submission: https://binarysearch.com/problems/Balanced-Brackets-Sequel/submissions/6943838
 */
public class P0036 {
  class Solution {
    public boolean solve(String s) {
      var stack = new Stack<Character>();

      for (int i = 0; i < s.length(); i++) {
        var ch = s.charAt(i);
        var peek = stack.empty() ? 'a' : stack.peek();

        var popped = false;
        if (ch == ')' && peek == '(') {
          stack.pop();
          popped = true;
        }
        if (ch == ']' && peek == '[') {
          stack.pop();
          popped = true;
        }
        if (ch == '}' && peek == '{') {
          stack.pop();
          popped = true;
        }

        if (!popped)
          stack.add(ch);
      }

      return stack.empty();
    }
  }
}