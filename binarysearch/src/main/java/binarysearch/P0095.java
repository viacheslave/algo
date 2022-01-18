package binarysearch;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Repeated-Deletion
 * Submission: https://binarysearch.com/problems/Repeated-Deletion/submissions/6943786
 */
public class P0095 {
  class Solution {
    public String solve(String s) {
      var st = new Stack<Character>();
      var index = 0;

      for (int i = 0; i < s.length(); i++) {
        var ch = s.charAt(i);

        if (st.empty() || (st.peek() != ch && index == 1)) {
          st.add(ch);
          index = 1;
          continue;
        }

        var peek = st.peek();
        if (peek == ch) {
          index++;
          continue;
        }

        if (index > 1) {
          st.pop();
          index = 1;
          i--;
        }
      }

      if (!st.empty() && index > 1)
        st.pop();

      var ans = new Stack<Character>();
      while (!st.empty())
        ans.add(st.pop());

      var sb = new StringBuilder();
      while (!ans.empty())
        sb.append(ans.pop());

      return sb.toString();
    }
  }
}