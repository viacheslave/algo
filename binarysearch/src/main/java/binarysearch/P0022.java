package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Add-Binary-Numbers
 * Submission: https://binarysearch.com/problems/Add-Binary-Numbers/submissions/6646600
 */
public class P0022 {
  class Solution {
    public String solve(String a, String b) {
      var length = Math.max(a.length(), b.length());

      var sb = new StringBuilder();
      var carry = 0;

      for (var i = 0; i < length; i++) {
        int left = 0;
        int right = 0;

        if (a.length() - 1 - i >= 0)
          left = Integer.parseInt(new String(new char[] {a.charAt(a.length() - 1 - i)}));

        if (b.length() - 1 - i >= 0)
          right = Integer.parseInt(new String(new char[] {b.charAt(b.length() - 1 - i)}));

        var sum = left + right + carry;

        if (sum % 2 == 0) {
          sb.insert(0, "0");
          carry = sum > 1 ? 1 : 0;
        } else {
          sb.insert(0, "1");
          carry = sum > 2 ? 1 : 0;
        }
      }

      if (carry == 1)
        sb.insert(0, "1");

      return sb.toString();
    }
  }
}