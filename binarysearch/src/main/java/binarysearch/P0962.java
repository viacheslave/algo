package binarysearch;

import java.util.Arrays;
import java.util.Comparator;
import java.util.Map;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Bulk-Shift-Letters
 * Submission: https://binarysearch.com/problems/Bulk-Shift-Letters/submissions/6700393
 */
public class P0962 {
  class Solution {
    public String solve(String s, int[] shifts) {
      for (var i = shifts.length - 1; i >= 0; i--)
        shifts[i] = (shifts[i] + ((i == shifts.length - 1) ? 0 : (shifts[i + 1] % 26))) % 26;

      var sb = new StringBuilder(s);

      for (int i = 0; i < shifts.length; i++)
        sb.setCharAt(i, (char)(((shifts[i] + ((int)sb.charAt(i)) - 97) % 26) + 97));

      return sb.toString();
    }
  }
}