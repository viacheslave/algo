package binarysearch;

import java.util.ArrayList;
import java.util.Map;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Phone-Number-Combinations
 * Submission: https://binarysearch.com/problems/Phone-Number-Combinations/submissions/6945361
 */
public class P0213 {
  class Solution {
    public String[] solve(String digits) {
      var ans = new ArrayList<String>();
      var buffer = new StringBuilder(digits.length());

      for (int i = 0; i < digits.length(); i++) {
        buffer.append(0);
      }

      var map = Map.ofEntries(
        Map.entry('2', "abc"),
        Map.entry('3', "def"),
        Map.entry('4', "ghi"),
        Map.entry('5', "jkl"),
        Map.entry('6', "mno"),
        Map.entry('7', "pqrs"),
        Map.entry('8', "tuv"),
        Map.entry('9', "wxyz")
      );

      rec(digits, 0, buffer, ans, map);

      return ans.toArray(new String[0]);
    }

    private void rec(String digits, int pos, StringBuilder buffer, ArrayList<String> ans, Map<Character, String> map) {
      if (pos == digits.length()) {
        ans.add(buffer.toString());
        return;
      }

      var digit = digits.charAt(pos);
      var values = map.get(digit);

      for (int i = 0; i < values.length(); i++) {
        buffer.setCharAt(pos, values.charAt(i));

        rec(digits, pos + 1, buffer, ans, map);
      }
    }
  }
}