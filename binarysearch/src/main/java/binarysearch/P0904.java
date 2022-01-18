package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Vertical-Word-Arrangement
 * Submission: https://binarysearch.com/problems/Vertical-Word-Arrangement/submissions/7173513
 */
public class P0904 {
  class Solution {
    public String[] solve(String s) {
      var strings = s.split("\\s+");

      var maxLength = Arrays.stream(strings).mapToInt(String::length).max().getAsInt();

      var ans = new ArrayList<String>();

      for (int i = 0; i < maxLength; i++) {
        var sb = new StringBuilder();

        for (int j = 0; j < strings.length; j++) {
          if (i < strings[j].length()) {
            sb.append(strings[j].charAt(i));
          }
          else {
            sb.append(' ');
          }
        }

        ans.add(sb.toString());
      }

      return ans.stream().map(String::stripTrailing).toArray(String[]::new);
    }
  }
}